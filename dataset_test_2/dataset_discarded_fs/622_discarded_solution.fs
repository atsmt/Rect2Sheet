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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(120.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(120.000000, 0.000000) * millimeter, vector(120.000000, 100.000000) * millimeter, vector(96.000000, 130.000000) * millimeter, vector(96.000000, 140.000000) * millimeter, vector(19.930800, 140.000000) * millimeter, vector(19.930800, 130.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-10.000000, 100.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(120.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(64.150239, 65.120079, 0.000000) * millimeter),
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

        // === Child Tab 1_0 from 0 (one_bend) ===
        // Flange 0->1_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(62.034600, 140.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0
        var sketchRem1_0 = newSketchOnPlane(context, id + "sketchRem1_0", { "sketchPlane" : plane(vector(110.0, 140.0, -20.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0, "polyRem1_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-80.000000, 0.000000) * millimeter, vector(-9.930800, -10.000000) * millimeter, vector(-9.930800, -18.000000) * millimeter, vector(-86.000000, -18.000000) * millimeter, vector(-86.000000, -10.000000) * millimeter, vector(-80.000000, 55.000000) * millimeter, vector(0.000000, 55.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0);
        sheetMetalTab(context, id + "smTab1_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0"), vector(62.034600, 140.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0", EntityType.FACE), vector(62.034600, 140.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_1 from 0 (two_bend) ===
        // Flange 0->1_0_1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(130.000000, 50.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0_1_1
        var sketchRem1_0_1_1a = newSketchOnPlane(context, id + "sketchRem1_0_1_1a", { "sketchPlane" : plane(vector(130.0, 100.0, -10.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_1_1a, "polyRem1_0_1_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-130.000000, -30.000000) * millimeter, vector(-128.000000, -40.000000) * millimeter, vector(-73.000000, -40.000000) * millimeter, vector(-75.000000, -30.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1_1a);
        sheetMetalTab(context, id + "smTab1_0_1_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1_1a"), vector(130.000000, 50.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_1_1a", EntityType.FACE), vector(130.000000, 50.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1_1->1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(130.000000, 140.000000, -112.500000) * millimeter),
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

        // Remaining polygon for tab 1_1
        var sketchRem1_1b = newSketchOnPlane(context, id + "sketchRem1_1b", { "sketchPlane" : plane(vector(110.0, 140.0, -85.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_1b, "polyRem1_1b", { "points" : [vector(-80.000000, 0.000000) * millimeter, vector(-80.000000, 55.000000) * millimeter, vector(18.000000, 55.000000) * millimeter, vector(18.000000, 0.000000) * millimeter, vector(-80.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1b);
        sheetMetalTab(context, id + "smTab1_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1b"), vector(125.000000, 140.000000, -112.500000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_1_1_1_1b", EntityType.FACE), vector(125.000000, 140.000000, -112.500000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });