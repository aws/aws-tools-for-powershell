/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Amazon.Runtime;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// Sets a default AWS region into the shell environment, accessible as $StoredAWSRegion.
    /// </para>
    /// <para>
    /// <br/><br/>
    /// <b>Note:</b> The regions available for tab completion to the -Region parameter were those known
    /// at the time this module was built. Regions launched subsequent to the build will not be listed for
    /// tab completion but can still be used by simply entering the region system name.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "DefaultAWSRegion")]
    [AWSCmdlet("Sets a default AWS region system name (e.g. us-west-2, eu-west-1 etc) into the shell variable $StoredAWSRegion. "
                + "AWS cmdlets will use the value of this variable to satisfy their -Region parameter if the parameter is not specified.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetDefaultRegionCmdlet : AWSRegionArgumentsCmdlet
    {
        /// <summary>
        /// <para>
        /// This parameter allows to specify the scope of the region configuration to set.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public VariableScope Scope { get; set; }

        protected override void ProcessRecord()
        {
            var region = this.GetRegion(true, SessionState);
            string scope = MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope.ToString() + ":" : "";
            this.SessionState.PSVariable.Set(scope + SessionKeys.AWSRegionVariableName, region.SystemName);
        }
    }

    /// <summary>
    /// Clears any default AWS region set in the shell variable $StoredAWSRegion.
    /// </summary>
    [Cmdlet("Clear", "DefaultAWSRegion")]
    [AWSCmdlet("Clears any default AWS region set in the shell variable $StoredAWSRegion.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class ClearDefaultRegionCmdlet : PSCmdlet
    {
        /// <summary>
        /// <para>
        /// This parameter allows to specify the scope of the region configuration to clear.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory =false)]
        public VariableScope Scope { get; set; }

        protected override void ProcessRecord()
        {
            string scope = MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope.ToString() + ":" : "";
            this.SessionState.PSVariable.Set(scope + SessionKeys.AWSRegionVariableName, null);
        }
    }

    /// <summary>
    /// Returns the current default AWS region for this shell, if any, as held in the shell variable $StoredAWSRegion.
    /// </summary>
    [Cmdlet("Get", "DefaultAWSRegion")]
    [OutputType(typeof(AWSRegion))]
    [AWSCmdlet("Returns the current default AWS region for this shell, if any, as held in the shell variable $StoredAWSRegion.")]
    [AWSCmdletOutput("AWSRegion", "AWSRegion instance mapping to the default AWS region stored in $StoredAWSRegion.")]
    public class GetDefaultRegionCmdlet : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var region = this.SessionState.PSVariable.Get(SessionKeys.AWSRegionVariableName);
            if (region != null && region.Value != null)
            {
                var rep = RegionEndpoint.GetBySystemName(region.Value.ToString());
                WriteObject(new AWSRegion(rep, this.SessionState));
            }
        }
    }

    /// <summary>
    /// <para>
    /// Returns the set of available AWS regions.
    /// </para>
    /// <para>
    /// <br/><br/>
    /// <b>Note:</b> The regions listed as output for this cmdlet are those known
    /// at the time this module was built. Regions launched subsequent to the build 
    /// will not be listed in the output. The new regions can still be used with the
    /// -Region parameter for cmdlets in this module by simply entering the region
    /// system name (eg us-west-2, eu-west-3 etc).
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSRegion", DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AWSRegion))]
    [AWSCmdlet("Returns the set of available AWS regions.")]
    [AWSCmdletOutput("AWSRegion", "AWSRegion instance for each available region.")]
    public class GetRegionCmdlet : PSCmdlet
    {
        private const string DefaultParameterSet = "PublicOnly";
        private const string PublicAndGovCloudParameterSet = "PublicAndGovCloud";
        private const string GovCloudOnlyParameterSet = "GovCloudOnly";

#region Parameter SystemName
        /// <summary>
        /// <para>
        /// If set returns an AWSRegion instance corresponding to the specified system name (e.g. us-west-2).
        /// </para>
        /// <para>
        /// This parameter can also be used to return AWSRegion instances for the US GovCloud and China (Beijing)
        /// regions by specifying the relevant system name.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DefaultParameterSet)]
        [Parameter(ParameterSetName = PublicAndGovCloudParameterSet, ValueFromPipelineByPropertyName = true)]
        public string SystemName { get; set; }
#endregion

#region Parameter IncludeChina
        /// <summary>
        /// <para>
        /// Include the China (Beijing) region in the returned collection of AWSRegion instances. 
        /// Note that use of this region requires an alternate set of credentials.
        /// </para>
        /// <para>
        /// This switch is ignored if the SystemName parameter is used to request a specific
        /// AWSRegion instance. To return the specific China (Beijing) region, specify a
        /// value of 'cn-north-1' for the SystemName parameter.
        /// </para>
        /// <para>Default: off.</para>
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = PublicAndGovCloudParameterSet, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter IncludeChina { get; set; }
#endregion

#region Parameter IncludeGovCloud
        /// <summary>
        /// <para>If set the returned collection includes 'Gov Cloud' region(s).</para>
        /// <para>Default: off.</para>
        /// </summary>
        [Parameter(ParameterSetName = PublicAndGovCloudParameterSet, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter IncludeGovCloud { get; set; }
#endregion

#region Parameter GovCloudOnly
        /// <summary>
        /// <para>If set the returned collection contains only the 'Gov Cloud' region(s).</para>
        /// <para>Default: off.</para>
        /// </summary>
        [Parameter(ParameterSetName = GovCloudOnlyParameterSet, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter GovCloudOnly { get; set; }
#endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrEmpty(SystemName))
            {
                try
                {
                    WriteObject(new AWSRegion(RegionEndpoint.GetBySystemName(SystemName), this.SessionState));
                }
                catch (Exception e)
                {
                    this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Unrecognized region system name", e),
                                                                "ArgumentException",
                                                                ErrorCategory.InvalidArgument,
                                                                this.SystemName));
                }
            }
            else
            {
                foreach (var region in RegionEndpoint.EnumerableAllRegions)
                {
                    // this is the only way we have to test at the moment
                    var isGovCloudRegion = region.SystemName.StartsWith("us-gov-", StringComparison.OrdinalIgnoreCase);
                    if (isGovCloudRegion)
                    {
                        if (this.IncludeGovCloud || this.GovCloudOnly)
                            WriteObject(new AWSRegion(region, this.SessionState));
                    }
                    else
                    {
                        if (this.GovCloudOnly)
                            continue;

                        if (region.SystemName.StartsWith("cn-", StringComparison.OrdinalIgnoreCase) && !this.IncludeChina)
                            continue;

                        WriteObject(new AWSRegion(region, this.SessionState));
                    }
                }
            }
        }
    }

    /// <summary>
    /// Information about a specific AWS region
    /// </summary>
    public class AWSRegion
    {
        readonly SessionState _sessionState;

        /// <summary>
        /// AWS system name for the region, for example 'us-west-2'. 
        /// </summary>
        public string Region { get; private set; }

        /// <summary>
        /// The descriptive name for the region, for example 'US East (Virginia)'
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Set to true if the region is the current default for the shell
        /// </summary>
        public bool IsShellDefault
        {
            get
            {
                var shellRegion = this._sessionState.PSVariable.Get(SessionKeys.AWSRegionVariableName);
                return (shellRegion != null
                            && shellRegion.Value != null
                            && string.Compare(this.Region, 
                                              shellRegion.Value.ToString(), 
                                              StringComparison.OrdinalIgnoreCase) == 0);
            }
        }

        public override string ToString()
        {
            return this.Region;
        }

        internal AWSRegion(RegionEndpoint rep, SessionState sessionState)
        {
            this.Region = rep.SystemName;
            this.Name = rep.DisplayName;
            this._sessionState = sessionState;
        }
    }
}
