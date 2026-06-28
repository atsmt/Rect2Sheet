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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(180.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(47.647100, -20.000000) * millimeter, vector(47.647100, -30.000000) * millimeter, vector(132.352900, -30.000000) * millimeter, vector(132.352900, -20.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(180.000000, 100.000000) * millimeter, vector(119.655200, 140.000000) * millimeter, vector(119.655200, 150.000000) * millimeter, vector(64.655200, 150.000000) * millimeter, vector(64.655200, 140.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-10.000000, 100.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(93.231241, 55.241002, 0.000000) * millimeter),
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
        // Flange 0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, 50.000000, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(180.0, -30.0, -50.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(47.647100, -40.000000) * millimeter, vector(47.647100, -50.000000) * millimeter, vector(132.352900, -50.000000) * millimeter, vector(132.352900, -40.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(180.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(90.000000, -30.000000, -112.181825) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(190.000000, 50.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_0 from 0 (one_bend) ===
        // Flange 0->2_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(87.844800, 150.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 2_0
        var sketchRem2_0 = newSketchOnPlane(context, id + "sketchRem2_0", { "sketchPlane" : plane(vector(105.0, 150.0, 20.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_0, "polyRem2_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(10.344800, -10.000000) * millimeter, vector(10.344800, -18.000000) * millimeter, vector(-44.655200, -18.000000) * millimeter, vector(-44.655200, -10.000000) * millimeter, vector(-35.000000, 0.000000) * millimeter, vector(-35.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_0);
        sheetMetalTab(context, id + "smTab2_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_0"), vector(87.844800, 150.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2_0", EntityType.FACE), vector(87.844800, 150.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_1 from 0 (two_bend) ===
        // Flange 0->1_0_2_1: bend=108.14deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, 50.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 108.135087 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_2_1
        var wallFace1_0_2_1a = qClosestTo(qCreatedBy(id + "flange0_1_0_2_1a", EntityType.FACE), vector(188.443708, 50.000000, 4.751626) * millimeter);
        var faceN1_0_2_1a = evPlane(context, { "face" : wallFace1_0_2_1a }).normal;
        var skN1_0_2_1a = dot(faceN1_0_2_1a, vector(-0.9503252976, 0.0, -0.3112584598)) >= 0 ? faceN1_0_2_1a : -faceN1_0_2_1a;
        var sketchRem1_0_2_1a = newSketchOnPlane(context, id + "sketchRem1_0_2_1a", { "sketchPlane" : plane(vector(186.8874, 100.0, 9.5033) * millimeter, skN1_0_2_1a, vector(0.3112584598, 0.0, -0.9503252976)) });
        skPolyline(sketchRem1_0_2_1a, "polyRem1_0_2_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000049, 0.000000) * millimeter, vector(8.000049, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-98.873540, -40.000000) * millimeter, vector(-96.873540, -50.000000) * millimeter, vector(-19.456728, -50.000000) * millimeter, vector(-21.456728, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2_1a);
        sheetMetalTab(context, id + "smTab1_0_2_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2_1a"), vector(188.443708, 100.000000, 4.751626) * millimeter),
            "booleanUnionScope" : wallFace1_0_2_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2_1->2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_1_2_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(168.160650, 150.000000, 66.679800) * millimeter),
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

        // Remaining polygon for tab 2_1
        var sketchRem2_1b = newSketchOnPlane(context, id + "sketchRem2_1b", { "sketchPlane" : plane(vector(150.0, 150.0, 20.0) * millimeter, vector(0.0, 1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_1b, "polyRem2_1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(35.000000, 0.000000) * millimeter, vector(35.000000, 70.000000) * millimeter, vector(3.390800, 80.352800) * millimeter, vector(-4.211748, 82.842887) * millimeter, vector(-28.308248, 9.271687) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_1b);
        sheetMetalTab(context, id + "smTab2_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_1b"), vector(163.409021, 150.000000, 65.123517) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_2_1_2_1b", EntityType.FACE), vector(163.409021, 150.000000, 65.123517) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });