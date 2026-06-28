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
        var sketch0_0 = newSketchOnPlane(context, id + "sketch0_0", { "sketchPlane" : plane(vector(95.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(-95.000000, 120.000000) * millimeter, vector(-52.500000, 160.000000) * millimeter, vector(-52.500000, 170.000000) * millimeter, vector(-5.000000, 170.000000) * millimeter, vector(-5.000000, 160.000000) * millimeter, vector(-10.000000, 120.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(-95.000000, 0.000000) * millimeter, vector(-95.000000, 120.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(45.485460, 79.277674, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0_0 (two_bend) ===
        // Flange 0_0->3_0_0_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, 60.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 3_0_0_1
        var sketchRem3_0_0_1a = newSketchOnPlane(context, id + "sketchRem3_0_0_1a", { "sketchPlane" : plane(vector(190.0, 120.0, -10.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem3_0_0_1a, "polyRem3_0_0_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(-180.000000, -40.000000) * millimeter, vector(-178.000000, -50.000000) * millimeter, vector(-38.000000, -50.000000) * millimeter, vector(-40.000000, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_1a);
        sheetMetalTab(context, id + "smTab3_0_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_1a"), vector(190.000000, 60.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_1a", EntityType.FACE), vector(190.000000, 60.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_1->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, 170.000000, -120.000000) * millimeter),
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
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(0.0, 170.0, -50.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(42.500000, -40.000000) * millimeter, vector(44.500000, -50.000000) * millimeter, vector(92.000000, -50.000000) * millimeter, vector(90.000000, -40.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(188.000000, 0.000000) * millimeter, vector(188.000000, 140.000000) * millimeter, vector(180.000000, 140.000000) * millimeter, vector(155.172400, 150.000000) * millimeter, vector(157.172400, 160.000000) * millimeter, vector(26.827600, 160.000000) * millimeter, vector(24.827600, 150.000000) * millimeter, vector(0.000000, 140.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(185.000000, 170.000000, -120.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_0_0_1_1b", EntityType.FACE), vector(185.000000, 170.000000, -120.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0_0 (two_bend) ===
        // Flange 0_0->3_0_0_3: bend=26.56deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(137.500000, 130.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 3_0_0_3
        var wallFace3_0_0_3a = qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_3a", EntityType.FACE), vector(137.500000, 134.472146, 2.236048) * millimeter);
        var faceN3_0_0_3a = evPlane(context, { "face" : wallFace3_0_0_3a }).normal;
        var skN3_0_0_3a = dot(faceN3_0_0_3a, vector(0.0, 0.4472095955, -0.894429191)) >= 0 ? faceN3_0_0_3a : -faceN3_0_0_3a;
        var sketchRem3_0_0_3a = newSketchOnPlane(context, id + "sketchRem3_0_0_3a", { "sketchPlane" : plane(vector(180.0, 138.9443, 4.4721) * millimeter, skN3_0_0_3a, vector(0.0, -0.894429191, -0.4472095955)) });
        skPolyline(sketchRem3_0_0_3a, "polyRem3_0_0_3a", { "points" : [vector(8.000009, 0.000000) * millimeter, vector(8.000009, 85.000000) * millimeter, vector(0.000000, 85.000000) * millimeter, vector(-24.721341, 180.000000) * millimeter, vector(-32.721351, 180.000000) * millimeter, vector(-32.721351, 0.000000) * millimeter, vector(8.000009, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_3a);
        sheetMetalTab(context, id + "smTab3_0_0_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_3a"), vector(180.000000, 134.472146, 2.236048) * millimeter),
            "booleanUnionScope" : wallFace3_0_0_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_3->3: bend=116.56deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, 170.000000, 20.000000) * millimeter),
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

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange3_0_0_3_3b", EntityType.FACE), vector(90.000000, 170.000000, 25.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, -1.0, 0.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(0.0, 170.0, 30.0) * millimeter, skN3b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(180.000000, -8.000000) * millimeter, vector(180.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(90.000000, 170.000000, 30.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (one_bend) ===
        // Flange 1->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, 170.000000, -210.000000) * millimeter),
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

        // Remaining polygon for tab 2
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(180.0, 220.0, -210.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(24.827600, -40.000000) * millimeter, vector(24.827600, -48.000000) * millimeter, vector(155.172400, -48.000000) * millimeter, vector(155.172400, -40.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(180.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(90.000000, 175.000000, -210.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2", EntityType.FACE), vector(90.000000, 175.000000, -210.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });