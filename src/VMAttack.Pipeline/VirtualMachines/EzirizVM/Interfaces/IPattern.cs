﻿using System.Collections.Generic;
using AsmResolver.PE.DotNet.Cil;
using VMAttack.Pipeline.VirtualMachines.EzirizVM.Architecture;

namespace VMAttack.Pipeline.VirtualMachines.EzirizVM.Interfaces;

public interface IPattern
{
    /// <summary>
    ///     Pattern of CilOpCodes in order of top to bottom to check against CIL instruction bodies.
    /// </summary>
    IList<CilOpCode> Pattern { get; }

    /// <summary>
    ///     Whether this pattern allows to interchange Ldc OpCodes like Ldc_I4 and Ldc_I4_8
    /// </summary>
    bool InterchangeLdcI4OpCodes => false;

    /// <summary>
    ///     Whether this pattern allows to interchange Ldloc OpCodes like Ldloc and Ldloc.s
    /// </summary>
    bool InterchangeLdlocOpCodes => false;

    /// <summary>
    ///     Whether this pattern allows to interchange Stloc OpCodes like Stloc and Stloc.s
    /// </summary>
    bool InterchangeStlocOpCodes => false;

    /// <summary>
    ///     Whether this pattern allows to interchange Branch OpCodes like Br and Br.s
    /// </summary>
    bool InterchangeBranchesOpCodes => false;

    /// <summary>
    ///     Whether the body should only be the pattern.
    /// </summary>
    bool MatchEntireBody => true;

    /// <summary>
    ///     Additional verification to ensure the match is valid.
    /// </summary>
    /// <param name="method">Method to match Pattern against</param>
    /// <param name="index">Index of the pattern</param>
    /// <returns>Whether verification is successful</returns>
    bool Verify(EzirizHandler method) => Verify(method.Instructions);

    /// <summary>
    ///     Additional verification to ensure the match is valid.
    /// </summary>
    /// <param name="instructions">CIL instruction body to match Pattern against</param>
    /// <param name="index">Index of the pattern</param>
    /// <returns>Whether verification is successful</returns>
    bool Verify(IList<CilInstruction> instructions) => true;
}