FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(-40.000000, 6.302000) * millimeter, vector(-40.000000, 192.195100) * millimeter, vector(-30.000000, 192.195100) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(180.000000, 200.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(-30.000000, 6.302000) * millimeter, vector(-40.000000, 6.302000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(70.775685, 99.918775, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 3 from 0 (one_bend) ===
        // Flange 0->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-40.000000, 99.248550, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(-40.0, 180.0, 50.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(-11.727238, -40.020135) * millimeter, vector(-12.195100, -40.000000) * millimeter, vector(-11.726058, -40.000000) * millimeter, vector(-11.242043, -31.744632) * millimeter, vector(-60.975600, -40.000000) * millimeter, vector(-60.975600, -52.000000) * millimeter, vector(-100.487800, -52.000000) * millimeter, vector(-100.487800, -40.000000) * millimeter, vector(-9.605010, -3.823354) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(180.000000, 160.000000) * millimeter, vector(220.757900, -40.000000) * millimeter, vector(202.369400, -46.000000) * millimeter, vector(183.980900, -40.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(67.547533, -18.666200) * millimeter, vector(144.748333, -40.000000) * millimeter, vector(173.698000, -40.000000) * millimeter, vector(148.649248, -41.077985) * millimeter, vector(173.698000, -48.000000) * millimeter, vector(80.751450, -44.000000) * millimeter, vector(-12.195100, -48.000000) * millimeter, vector(-11.727238, -40.020135) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(-40.000000, 99.248550, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_3", EntityType.FACE), vector(-40.000000, 99.248550, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });