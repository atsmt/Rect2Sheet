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
        var sketch0_0 = newSketchOnPlane(context, id + "sketch0_0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(-40.000000, 14.558800) * millimeter, vector(-50.000000, 14.558800) * millimeter, vector(-50.000000, 88.235300) * millimeter, vector(-40.000000, 88.235300) * millimeter, vector(0.000000, 55.000000) * millimeter, vector(100.000000, 55.000000) * millimeter, vector(100.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(-40.000000, 14.558800) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(21.325594, 33.157485, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 51.397050, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(-50.0, 0.0, -30.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(14.558800, -20.000000) * millimeter, vector(14.558800, -28.000000) * millimeter, vector(88.235300, -28.000000) * millimeter, vector(88.235300, -20.000000) * millimeter, vector(120.000000, 0.000000) * millimeter, vector(130.000000, -2.000000) * millimeter, vector(130.000000, 198.000000) * millimeter, vector(120.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(-50.000000, 51.397050, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_1", EntityType.FACE), vector(-50.000000, 51.397050, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0_1 (two_bend) ===
        // Flange 0_1->3_0_1_2: bend=26.56deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_3_0_1_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 92.500000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 26.564795 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 3_0_1_2
        var wallFace3_0_1_2a = qClosestTo(qCreatedBy(id + "flange0_1_3_0_1_2a", EntityType.FACE), vector(-14.472146, 92.500000, 2.236048) * millimeter);
        var faceN3_0_1_2a = evPlane(context, { "face" : wallFace3_0_1_2a }).normal;
        var skN3_0_1_2a = dot(faceN3_0_1_2a, vector(-0.4472095955, 0.0, -0.894429191)) >= 0 ? faceN3_0_1_2a : -faceN3_0_1_2a;
        var sketchRem3_0_1_2a = newSketchOnPlane(context, id + "sketchRem3_0_1_2a", { "sketchPlane" : plane(vector(-18.9443, 120.0, 4.4721) * millimeter, skN3_0_1_2a, vector(0.894429191, 0.0, -0.4472095955)) });
        skPolyline(sketchRem3_0_1_2a, "polyRem3_0_1_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000009, 0.000000) * millimeter, vector(8.000009, 55.000000) * millimeter, vector(0.000000, 55.000000) * millimeter, vector(-24.721341, 80.000000) * millimeter, vector(-32.721351, 80.000000) * millimeter, vector(-32.721351, 10.000000) * millimeter, vector(-24.721341, 10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_1_2a);
        sheetMetalTab(context, id + "smTab3_0_1_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_1_2a"), vector(-14.472146, 120.000000, 2.236048) * millimeter),
            "booleanUnionScope" : wallFace3_0_1_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_1_2->2: bend=116.56deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_1_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 75.000000, 20.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 116.564795 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange3_0_1_2_2b", EntityType.FACE), vector(-50.000000, 75.000000, 25.000000) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(1.0, 0.0, 0.0)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(-50.0, 40.0, 30.0) * millimeter, skN2b, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(70.000000, -8.000000) * millimeter, vector(70.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(-50.000000, 75.000000, 30.000000) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });
    });