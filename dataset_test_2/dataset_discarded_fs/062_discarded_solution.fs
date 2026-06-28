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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(200.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, -10.000000) * millimeter, vector(200.000000, -10.000000) * millimeter, vector(200.000000, 80.000000) * millimeter, vector(147.500000, 100.000000) * millimeter, vector(147.500000, 110.000000) * millimeter, vector(0.000000, 110.000000) * millimeter, vector(0.000000, -10.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(103.574346, 47.750545, 0.000000) * millimeter),
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
        // Flange 0->1_0_1_0: bend=126.87deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1_0a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(100.000000, -10.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 126.869898 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_1_0
        var wallFace1_0_1_0a = qClosestTo(qCreatedBy(id + "flange0_1_0_1_0a", EntityType.FACE), vector(100.000000, -7.000000, 4.000000) * millimeter);
        var faceN1_0_1_0a = evPlane(context, { "face" : wallFace1_0_1_0a }).normal;
        var skN1_0_1_0a = dot(faceN1_0_1_0a, vector(0.0, 0.8, -0.6)) >= 0 ? faceN1_0_1_0a : -faceN1_0_1_0a;
        var sketchRem1_0_1_0a = newSketchOnPlane(context, id + "sketchRem1_0_1_0a", { "sketchPlane" : plane(vector(200.0, -4.0, 8.0) * millimeter, skN1_0_1_0a, vector(0.0, -0.6, -0.8)) });
        skPolyline(sketchRem1_0_1_0a, "polyRem1_0_1_0a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 200.000000) * millimeter, vector(-188.000000, 200.000000) * millimeter, vector(-188.000000, 105.000000) * millimeter, vector(-180.000000, 105.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1_0a);
        sheetMetalTab(context, id + "smTab1_0_1_0a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1_0a"), vector(200.000000, -7.000000, 4.000000) * millimeter),
            "booleanUnionScope" : wallFace1_0_1_0a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1_0->1_0: bend=143.13deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_0_1_0b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(47.500000, 110.000000, 160.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 143.130102 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0
        var wallFace1_0b = qClosestTo(qCreatedBy(id + "flange1_0_1_0_1_0b", EntityType.FACE), vector(47.500000, 110.000000, 155.000000) * millimeter);
        var faceN1_0b = evPlane(context, { "face" : wallFace1_0b }).normal;
        var skN1_0b = dot(faceN1_0b, vector(0.0, 1.0, 0.0)) >= 0 ? faceN1_0b : -faceN1_0b;
        var sketchRem1_0b = newSketchOnPlane(context, id + "sketchRem1_0b", { "sketchPlane" : plane(vector(95.0, 110.0, 30.0) * millimeter, skN1_0b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0b, "polyRem1_0b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(95.000000, 0.000000) * millimeter, vector(95.000000, 128.000000) * millimeter, vector(0.000000, 128.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0b);
        sheetMetalTab(context, id + "smTab1_0b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0b"), vector(47.500000, 110.000000, 30.000000) * millimeter),
            "booleanUnionScope" : wallFace1_0b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_1 from 0 (one_bend) ===
        // Flange 0->1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(126.250000, 110.000000, 0.000000) * millimeter),
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
        var sketchRem1_1 = newSketchOnPlane(context, id + "sketchRem1_1", { "sketchPlane" : plane(vector(200.0, 110.0, 30.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_1, "polyRem1_1", { "points" : [vector(0.000000, -28.000000) * millimeter, vector(-147.500000, -28.000000) * millimeter, vector(-147.500000, -20.000000) * millimeter, vector(-95.000000, 0.000000) * millimeter, vector(-95.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(0.000000, -28.000000) * millimeter] });
        skSolve(sketchRem1_1);
        sheetMetalTab(context, id + "smTab1_1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1"), vector(126.250000, 110.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_1", EntityType.FACE), vector(126.250000, 110.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });