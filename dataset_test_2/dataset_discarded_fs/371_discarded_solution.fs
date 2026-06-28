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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(180.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(120.000000, -230.000000) * millimeter, vector(110.030800, -280.000000) * millimeter, vector(110.030800, -290.000000) * millimeter, vector(17.704900, -290.000000) * millimeter, vector(17.704900, -280.000000) * millimeter, vector(0.000000, -230.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(180.000000, 80.000000) * millimeter, vector(180.000000, -10.000000) * millimeter, vector(120.000000, -40.000000) * millimeter, vector(120.000000, -230.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(108.510468, -85.055728, 0.000000) * millimeter),
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

        // === Child Tab 3 from 1 (one_bend) ===
        // Flange 1->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(116.132150, -290.000000, 0.000000) * millimeter),
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
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(70.0, -290.0, 50.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, 120.000000) * millimeter, vector(80.000000, 120.000000) * millimeter, vector(92.295100, -40.000000) * millimeter, vector(92.295100, -48.000000) * millimeter, vector(-0.030800, -48.000000) * millimeter, vector(-0.030800, -40.000000) * millimeter, vector(63.993840, -8.000000) * millimeter, vector(0.000000, -8.000000) * millimeter, vector(0.000000, 120.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(116.132150, -290.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_3", EntityType.FACE), vector(116.132150, -290.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });