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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(116.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(126.000000, 0.000000) * millimeter, vector(126.000000, 175.000000) * millimeter, vector(116.000000, 175.000000) * millimeter, vector(114.997000, 194.000000) * millimeter, vector(114.997000, 204.000000) * millimeter, vector(7.000000, 204.000000) * millimeter, vector(7.000000, 194.000000) * millimeter, vector(0.000000, 175.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(53.382020, 100.430156, 0.000000) * millimeter),
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

        // === Child Tab 1_0 from 0 (two_bend) ===
        // Flange 0->1_0_1_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1_0a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 87.500000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0_1_0
        var sketchRem1_0_1_0a = newSketchOnPlane(context, id + "sketchRem1_0_1_0a", { "sketchPlane" : plane(vector(-10.0, 175.0, 10.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem1_0_1_0a, "polyRem1_0_1_0a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 175.000000) * millimeter, vector(0.000000, 175.000000) * millimeter, vector(-281.000000, -19.000000) * millimeter, vector(-279.000000, -29.000000) * millimeter, vector(-17.000000, -29.000000) * millimeter, vector(-19.000000, -19.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1_0a);
        sheetMetalTab(context, id + "smTab1_0_1_0a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1_0a"), vector(-10.000000, 87.500000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_1_0a", EntityType.FACE), vector(-10.000000, 87.500000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1_0->1_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_0_1_0b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 204.000000, 160.000000) * millimeter),
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

        // Remaining polygon for tab 1_0
        var sketchRem1_0b = newSketchOnPlane(context, id + "sketchRem1_0b", { "sketchPlane" : plane(vector(46.0, 204.0, 29.0) * millimeter, vector(0.0, 1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0b, "polyRem1_0b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(54.000000, 0.000000) * millimeter, vector(54.000000, 262.000000) * millimeter, vector(0.000000, 262.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0b);
        sheetMetalTab(context, id + "smTab1_0b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0b"), vector(-5.000000, 204.000000, 160.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_1_0_1_0b", EntityType.FACE), vector(-5.000000, 204.000000, 160.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_1 from 0 (one_bend) ===
        // Flange 0->1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(55.001500, 204.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_1
        var sketchRem1_1 = newSketchOnPlane(context, id + "sketchRem1_1", { "sketchPlane" : plane(vector(102.0, 204.0, 29.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_1, "polyRem1_1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-46.000000, 0.000000) * millimeter, vector(-46.000000, 262.000000) * millimeter, vector(0.000000, 262.000000) * millimeter, vector(7.000000, -19.000000) * millimeter, vector(7.000000, -27.000000) * millimeter, vector(-100.997000, -27.000000) * millimeter, vector(-100.997000, -19.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1);
        sheetMetalTab(context, id + "smTab1_1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1"), vector(55.001500, 204.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_1", EntityType.FACE), vector(55.001500, 204.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });