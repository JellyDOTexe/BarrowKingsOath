using UnityEngine;

namespace BarrowKingsMaul
{
    // Cold cyan spirit motes rising from the maul head, plus a dim light.
    // Reuses the glow particle material that the cloned Iron Mace already carries (attach/UpgraderGlow).
    internal static class HeadGlow
    {
        internal static readonly Color Cyan = new Color(0.55f, 1f, 0.95f);

        internal static void Add(Transform model, Bounds head)
        {
            var all = model.root.GetComponentsInChildren<ParticleSystemRenderer>(true);
            var src = System.Array.Find(all, r => r.transform.parent != null && r.transform.parent.name == "UpgraderGlow") ?? (all.Length > 0 ? all[0] : null);
            if (src == null || src.sharedMaterial == null) { Plugin.Log.LogWarning("No glow material found; head particles skipped"); return; }

            var go = new GameObject("spirit_motes") { layer = model.gameObject.layer };
            go.transform.SetParent(model, false);
            go.transform.localPosition = head.center;

            var ps = go.AddComponent<ParticleSystem>();
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            var main = ps.main;
            main.loop = true;
            main.duration = 1f;
            main.startLifetime = new ParticleSystem.MinMaxCurve(0.6f, 1.2f);
            main.startSpeed = new ParticleSystem.MinMaxCurve(0.02f, 0.08f);
            main.startSize = new ParticleSystem.MinMaxCurve(0.03f, 0.07f);
            main.startColor = new ParticleSystem.MinMaxGradient(new Color(Cyan.r, Cyan.g, Cyan.b, 0.8f), new Color(1f, 1f, 1f, 0.6f));
            main.gravityModifier = -0.05f;                      // drift upward
            main.simulationSpace = ParticleSystemSimulationSpace.World;   // leaves a faint trail when swung
            main.maxParticles = 60;

            var em = ps.emission; em.rateOverTime = 22f;
            var sh = ps.shape;
            sh.shapeType = ParticleSystemShapeType.Sphere;
            sh.radius = Mathf.Max(0.05f, Mathf.Min(head.extents.x, head.extents.y) * 0.9f);
            sh.radiusThickness = 0.2f;                          // spawn near the surface

            var col = ps.colorOverLifetime; col.enabled = true;
            var g = new Gradient();
            g.SetKeys(new[] { new GradientColorKey(Cyan, 0f), new GradientColorKey(Color.white, 1f) },
                      new[] { new GradientAlphaKey(0f, 0f), new GradientAlphaKey(0.9f, 0.2f), new GradientAlphaKey(0f, 1f) });
            col.color = g;
            var size = ps.sizeOverLifetime; size.enabled = true;
            size.size = new ParticleSystem.MinMaxCurve(1f, AnimationCurve.EaseInOut(0f, 1f, 1f, 0.2f));

            var r = go.GetComponent<ParticleSystemRenderer>();
            r.sharedMaterial = src.sharedMaterial;
            r.renderMode = ParticleSystemRenderMode.Billboard;
            ps.Play();

            var light = go.AddComponent<Light>();
            light.type = LightType.Point;
            light.color = Cyan;
            light.range = 1.6f;
            light.intensity = 0.6f;
            light.shadows = LightShadows.None;
        }
    }
}
