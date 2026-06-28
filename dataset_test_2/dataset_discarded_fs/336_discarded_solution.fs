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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, -10.000000) * millimeter, vector(0.000000, 210.000000) * millimeter, vector(180.000000, 210.000000) * millimeter, vector(180.000000, -10.000000) * millimeter, vector(130.000000, -40.000000) * millimeter, vector(130.000000, -230.000000) * millimeter, vector(60.000000, -230.000000) * millimeter, vector(60.000000, -40.000000) * millimeter, vector(0.000000, -10.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(91.315093, 36.699029, 0.000000) * millimeter),
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

        // === Child Tab 3 from 0 (two_bend) ===
        // Flange 0->1_0_3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, 210.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_3
        var sketchRem1_0_3a = newSketchOnPlane(context, id + "sketchRem1_0_3a", { "sketchPlane" : plane(vector(0.0, 210.0, 10.0) * millimeter, vector(0.0, -1.0, 0.0), vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem1_0_3a, "polyRem1_0_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 180.000000) * millimeter, vector(0.000000, 180.000000) * millimeter, vector(-200.000000, -30.000000) * millimeter, vector(-198.000000, -40.000000) * millimeter, vector(-38.000000, -40.000000) * millimeter, vector(-40.000000, -30.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_3a);
        sheetMetalTab(context, id + "smTab1_0_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_3a"), vector(90.000000, 210.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_3a", EntityType.FACE), vector(90.000000, 210.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_3->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-40.000000, 210.000000, 130.000000) * millimeter),
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
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(-40.0, 180.0, 50.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(100.487800, -40.000000) * millimeter, vector(102.487800, -50.000000) * millimeter, vector(62.975600, -50.000000) * millimeter, vector(60.975600, -40.000000) * millimeter, vector(-180.000000, 0.000000) * millimeter, vector(-180.000000, 160.000000) * millimeter, vector(28.000000, 160.000000) * millimeter, vector(28.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(-40.000000, 205.000000, 130.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_3_3b", EntityType.FACE), vector(-40.000000, 205.000000, 130.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });