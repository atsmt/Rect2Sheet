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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(120.499900, -64.999900) * millimeter, vector(120.499900, -74.999900) * millimeter, vector(366.399100, -74.999900) * millimeter, vector(366.399100, -64.999900) * millimeter, vector(378.000000, 0.000000) * millimeter, vector(443.000000, 44.421500) * millimeter, vector(453.000000, 44.421500) * millimeter, vector(453.000000, 106.578500) * millimeter, vector(443.000000, 106.578500) * millimeter, vector(378.000000, 151.000000) * millimeter, vector(0.000000, 151.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(215.454356, 46.870504, 0.000000) * millimeter),
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

        // === Child Tab 2 from 0 (one_bend) ===
        // Flange 0->2: bend=64.32deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(243.449500, -74.999900, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 64.323400 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var wallFace2 = qClosestTo(qCreatedBy(id + "flange0_2", EntityType.FACE), vector(243.449500, -77.166355, -4.506270) * millimeter);
        var faceN2 = evPlane(context, { "face" : wallFace2 }).normal;
        var skN2 = dot(faceN2, vector(0.0, 0.9012540536, -0.4332910463)) >= 0 ? faceN2 : -faceN2;
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(90.0, -107.4968, -67.5941) * millimeter, skN2, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(0.000000, 377.999964) * millimeter, vector(151.000000, 377.999964) * millimeter, vector(276.399100, -65.000070) * millimeter, vector(276.399100, -73.000072) * millimeter, vector(143.999800, -73.000072) * millimeter, vector(143.999800, -76.999939) * millimeter, vector(30.500100, -76.999939) * millimeter, vector(30.499900, -73.000072) * millimeter, vector(30.499900, -65.000070) * millimeter, vector(30.500093, -64.999966) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(243.449500, -107.496760, -67.594119) * millimeter),
            "booleanUnionScope" : wallFace2,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 2 (one_bend) ===
        // Flange 2->3: bend=25.68deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(177.249950, -75.000000, -0.000100) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 25.676600 * degree,
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