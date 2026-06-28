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
        skPolyline(sketch0, "poly0", { "points" : [vector(378.000000, 0.000000) * millimeter, vector(443.000000, 44.421500) * millimeter, vector(453.000000, 44.421500) * millimeter, vector(453.000000, 106.578500) * millimeter, vector(443.000000, 106.578500) * millimeter, vector(378.000000, 151.000000) * millimeter, vector(-10.000000, 151.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(378.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(209.733128, 75.500000, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=52.93deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(453.000000, 75.500000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 52.933334 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1 = qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(456.013719, 75.500000, -3.989674) * millimeter);
        var faceN1 = evPlane(context, { "face" : wallFace1 }).normal;
        var skN1 = dot(faceN1, vector(-0.7979347372, 0.0, -0.6027438553)) >= 0 ? faceN1 : -faceN1;
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(475.3015, 0.0, -29.5236) * millimeter, skN1, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(44.421500, -27.000059) * millimeter, vector(44.421500, -34.999998) * millimeter, vector(106.578500, -34.999998) * millimeter, vector(106.578500, -27.000059) * millimeter, vector(151.000000, 0.000000) * millimeter, vector(151.000000, 132.000018) * millimeter, vector(0.000000, 132.000018) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(475.301522, 75.500000, -29.523584) * millimeter),
            "booleanUnionScope" : wallFace1,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0 (two_bend) ===
        // Flange 0->1_0_2: bend=102.41deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 75.500000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 102.405572 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_2
        var wallFace1_0_2a = qClosestTo(qCreatedBy(id + "flange0_1_0_2a", EntityType.FACE), vector(-8.925848, 75.500000, -4.883257) * millimeter);
        var faceN1_0_2a = evPlane(context, { "face" : wallFace1_0_2a }).normal;
        var skN1_0_2a = dot(faceN1_0_2a, vector(0.976651391, 0.0, 0.214830306)) >= 0 ? faceN1_0_2a : -faceN1_0_2a;
        var sketchRem1_0_2a = newSketchOnPlane(context, id + "sketchRem1_0_2a", { "sketchPlane" : plane(vector(-7.8517, 151.0, -9.7665) * millimeter, skN1_0_2a, vector(-0.214830306, 0.0, 0.976651391)) });
        skPolyline(sketchRem1_0_2a, "polyRem1_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999986, 0.000000) * millimeter, vector(7.999986, 151.000000) * millimeter, vector(0.000000, 151.000000) * millimeter, vector(-78.445402, 256.481100) * millimeter, vector(-72.195258, 265.532900) * millimeter, vector(-434.402538, 435.603500) * millimeter, vector(-440.652780, 426.551700) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2a);
        sheetMetalTab(context, id + "smTab1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2a"), vector(-8.925848, 151.000000, -4.883257) * millimeter),
            "booleanUnionScope" : wallFace1_0_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2->2: bend=95.34deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(46.994350, -199.568200, -259.104500) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 95.341055 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange1_0_2_2b", EntityType.FACE), vector(51.898901, -199.146908, -258.228204) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(0.0, 0.9012540536, -0.4332910463)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(90.0, -107.4968, -67.5941) * millimeter, skN2b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(30.500100, -64.999980) * millimeter, vector(28.538280, -74.611016) * millimeter, vector(142.037980, -74.611016) * millimeter, vector(143.999800, -64.999980) * millimeter, vector(151.000000, 0.000000) * millimeter, vector(151.000000, 377.999964) * millimeter, vector(5.710100, 406.803044) * millimeter, vector(-2.137180, 408.358750) * millimeter, vector(-79.950480, 15.849880) * millimeter, vector(-72.103200, 14.294174) * millimeter, vector(0.000000, 377.999964) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(51.898901, -107.496783, -67.594108) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 2 (one_bend) ===
        // Flange 2->3: bend=25.68deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(177.249950, -75.000000, -0.000100) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 25.676632 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 3
        var wallFace3 = qClosestTo(qCreatedBy(id + "flange2_3", EntityType.FACE), vector(177.249950, -75.000000, 4.999900) * millimeter);
        var faceN3 = evPlane(context, { "face" : wallFace3 }).normal;
        var skN3 = dot(faceN3, vector(0.0, -1.0, 0.0)) >= 0 ? faceN3 : -faceN3;
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(0.0, -75.0, 75.0) * millimeter, skN3, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(120.500100, -65.000100) * millimeter, vector(120.500100, -73.000100) * millimeter, vector(233.999800, -73.000100) * millimeter, vector(233.999800, -65.000100) * millimeter, vector(378.000000, 0.000000) * millimeter, vector(378.000000, 132.000000) * millimeter, vector(0.000000, 132.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(177.249950, -75.000000, 75.000000) * millimeter),
            "booleanUnionScope" : wallFace3,
            "booleanOffset" : 0.0 * millimeter
        });
    });