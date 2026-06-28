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

        // === Root Tab 0_0 ===
        var sketch0_0 = newSketchOnPlane(context, id + "sketch0_0", { "sketchPlane" : plane(vector(65.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(0.000000, 100.000000) * millimeter, vector(3.396200, 130.000000) * millimeter, vector(3.396200, 140.000000) * millimeter, vector(47.000000, 140.000000) * millimeter, vector(47.000000, 130.000000) * millimeter, vector(55.000000, 100.000000) * millimeter, vector(55.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(0.000000, 100.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(92.143908, 67.848351, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0_0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0_0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1 from 0_0 (one_bend) ===
        // Flange 0_0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.198100, 140.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(30.0, 140.0, -20.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-80.000000, 0.000000) * millimeter, vector(-38.396200, -10.000000) * millimeter, vector(-38.396200, -18.000000) * millimeter, vector(-82.000000, -18.000000) * millimeter, vector(-82.000000, -10.000000) * millimeter, vector(-80.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(6.000000, -10.000000) * millimeter, vector(6.000000, -22.000000) * millimeter, vector(-23.113200, -22.000000) * millimeter, vector(-23.113200, -10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(90.198100, 140.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_1", EntityType.FACE), vector(90.198100, 140.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });