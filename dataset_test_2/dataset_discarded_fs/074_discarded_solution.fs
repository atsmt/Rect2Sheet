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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(225.000000, 0.000000) * millimeter, vector(225.000000, 282.000000) * millimeter, vector(172.852900, 314.000000) * millimeter, vector(172.852900, 324.000000) * millimeter, vector(44.735300, 324.000000) * millimeter, vector(44.735300, 314.000000) * millimeter, vector(0.000000, 282.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(112.297397, 156.726013, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(108.794100, 324.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(169.0, 324.0, -70.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-3.852900, -60.000000) * millimeter, vector(-3.852900, -68.000000) * millimeter, vector(124.264700, -68.000000) * millimeter, vector(124.264700, -60.000000) * millimeter, vector(141.000000, 0.000000) * millimeter, vector(141.000000, 141.000000) * millimeter, vector(102.756100, 187.000000) * millimeter, vector(102.756100, 195.000000) * millimeter, vector(55.024400, 195.000000) * millimeter, vector(55.024400, 187.000000) * millimeter, vector(0.000000, 141.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(108.794100, 324.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(108.794100, 324.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (one_bend) ===
        // Flange 1->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.109750, 324.000000, -267.000000) * millimeter),
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

        // Remaining polygon for tab 2
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(28.0, 254.0, -267.0) * millimeter, vector(0.0, 0.0, -1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(38.243900, -60.000000) * millimeter, vector(38.243900, -68.000000) * millimeter, vector(85.975600, -68.000000) * millimeter, vector(85.975600, -60.000000) * millimeter, vector(98.000000, 0.000000) * millimeter, vector(98.000000, 181.000000) * millimeter, vector(0.000000, 181.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(90.109750, 319.000000, -267.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2", EntityType.FACE), vector(90.109750, 319.000000, -267.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 2 (two_bend) ===
        // Flange 2->1_2_3: bend=158.63deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1_2_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(77.000000, 75.000000, -267.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 158.629285 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_2_3
        var wallFace1_2_3a = qClosestTo(qCreatedBy(id + "flange2_1_2_3a", EntityType.FACE), vector(77.000000, 70.343789, -265.177996) * millimeter);
        var faceN1_2_3a = evPlane(context, { "face" : wallFace1_2_3a }).normal;
        var skN1_2_3a = dot(faceN1_2_3a, vector(0.0, 0.3644008568, 0.9312421895)) >= 0 ? faceN1_2_3a : -faceN1_2_3a;
        var sketchRem1_2_3a = newSketchOnPlane(context, id + "sketchRem1_2_3a", { "sketchPlane" : plane(vector(126.0, 65.6876, -263.356) * millimeter, skN1_2_3a, vector(0.0, 0.9312421895, -0.3644008568)) });
        skPolyline(sketchRem1_2_3a, "polyRem1_2_3a", { "points" : [vector(7.999976, 0.000000) * millimeter, vector(7.999976, 98.000000) * millimeter, vector(-37.396380, 98.000000) * millimeter, vector(-37.396380, 0.000000) * millimeter, vector(7.999976, 0.000000) * millimeter] });
        skSolve(sketchRem1_2_3a);
        sheetMetalTab(context, id + "smTab1_2_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_2_3a"), vector(126.000000, 70.343789, -265.177996) * millimeter),
            "booleanUnionScope" : wallFace1_2_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_2_3->3: bend=111.37deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(77.000000, 29.000000, -249.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 111.370715 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_2_3_3b", EntityType.FACE), vector(77.000000, 29.000000, -244.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, 1.0, 0.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(126.0, 29.0, -239.0) * millimeter, skN3b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(98.000000, -8.000000) * millimeter, vector(98.000000, 169.000000) * millimeter, vector(0.000000, 169.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(77.000000, 29.000000, -239.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });
    });