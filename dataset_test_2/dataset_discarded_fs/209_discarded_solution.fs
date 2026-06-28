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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(210.000000, 0.000000) * millimeter, vector(210.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(95.000000, 80.000000, 0.000000) * millimeter),
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

        // === Child Tab 1_1 from 0 (two_bend) ===
        // Flange 0->1_0_1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 80.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0_1_1
        var sketchRem1_0_1_1a = newSketchOnPlane(context, id + "sketchRem1_0_1_1a", { "sketchPlane" : plane(vector(-10.0, 160.0, -10.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_1_1a, "polyRem1_0_1_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(-100.000000, -30.000000) * millimeter, vector(-98.000000, -40.000000) * millimeter, vector(-63.000000, -40.000000) * millimeter, vector(-65.000000, -30.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1_1a);
        sheetMetalTab(context, id + "smTab1_0_1_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1_1a"), vector(-10.000000, 80.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_1_1a", EntityType.FACE), vector(-10.000000, 80.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1_1->1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 200.000000, -92.500000) * millimeter),
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
        var sketchRem1_1b = newSketchOnPlane(context, id + "sketchRem1_1b", { "sketchPlane" : plane(vector(200.0, 200.0, -75.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_1b, "polyRem1_1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(208.000000, 0.000000) * millimeter, vector(208.000000, 35.000000) * millimeter, vector(200.000000, 35.000000) * millimeter, vector(144.667000, 45.000000) * millimeter, vector(146.667000, 55.000000) * millimeter, vector(57.333000, 55.000000) * millimeter, vector(55.333000, 45.000000) * millimeter, vector(0.000000, 35.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1b);
        sheetMetalTab(context, id + "smTab1_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1b"), vector(-5.000000, 200.000000, -92.500000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_1_1_1_1b", EntityType.FACE), vector(-5.000000, 200.000000, -92.500000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1_1 (one_bend) ===
        // Flange 1_1->2: bend=115.41deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(100.000000, 200.000000, -130.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 115.410038 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var wallFace2 = qClosestTo(qCreatedBy(id + "flange1_1_2", EntityType.FACE), vector(100.000000, 204.516301, -132.145467) * millimeter);
        var faceN2 = evPlane(context, { "face" : wallFace2 }).normal;
        var skN2 = dot(faceN2, vector(0.0, -0.4290933942, -0.9032601281)) >= 0 ? faceN2 : -faceN2;
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(200.0, 236.1304, -147.1637) * millimeter, skN2, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(55.333000, -29.999996) * millimeter, vector(55.333000, -37.999980) * millimeter, vector(144.667000, -37.999980) * millimeter, vector(144.667000, -29.999996) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(210.000000, -2.000000) * millimeter, vector(210.000000, 117.999983) * millimeter, vector(200.000000, 119.999983) * millimeter, vector(0.000000, 119.999983) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(100.000000, 236.130387, -147.163727) * millimeter),
            "booleanUnionScope" : wallFace2,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_0 from 2 (one_bend) ===
        // Flange 2->1_0: bend=115.41deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 200.000000, -47.500000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 115.410038 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0
        var wallFace1_0 = qClosestTo(qCreatedBy(id + "flange2_1_0", EntityType.FACE), vector(-5.000000, 200.000000, -47.500000) * millimeter);
        var faceN1_0 = evPlane(context, { "face" : wallFace1_0 }).normal;
        var skN1_0 = dot(faceN1_0, vector(0.0, -1.0, 0.0)) >= 0 ? faceN1_0 : -faceN1_0;
        var sketchRem1_0 = newSketchOnPlane(context, id + "sketchRem1_0", { "sketchPlane" : plane(vector(200.0, 200.0, -30.0) * millimeter, skN1_0, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0, "polyRem1_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(212.000000, 0.000000) * millimeter, vector(212.000000, 35.000000) * millimeter, vector(0.000000, 35.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0);
        sheetMetalTab(context, id + "smTab1_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0"), vector(-5.000000, 200.000000, -30.000000) * millimeter),
            "booleanUnionScope" : wallFace1_0,
            "booleanOffset" : 0.0 * millimeter
        });
    });