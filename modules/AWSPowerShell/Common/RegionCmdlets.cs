/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Sets a default AWS region into the shell environment, accessible as $StoredAWSRegion.
    /// </summary>
    [Cmdlet("Set", "DefaultAWSRegion")]
    [AWSCmdlet("Sets a default AWS region system name (e.g. us-west-2, eu-west-1 etc) into the shell variable $StoredAWSRegion.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetDefaultRegionCmdlet : PSCmdlet, IDynamicParameters
    {
        private AWSRegionArguments Parameters { get; set; }

        protected override void ProcessRecord()
        {
            var region = Parameters.GetRegion(false);
            this.SessionState.PSVariable.Set(SessionKeys.AWSRegionVariableName, region.SystemName);
        }

        #region IDynamicParameters Members

        public object GetDynamicParameters()
        {
            Parameters = new AWSRegionArguments(this.SessionState);
            return Parameters;
        }

        #endregion
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
        protected override void ProcessRecord()
        {
            this.SessionState.PSVariable.Set(SessionKeys.AWSRegionVariableName, null);
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
    /// Returns the set of available AWS regions.
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

        /// <summary>
        /// <para>
        /// If set returns an AWSRegion instance corresponding to the specified system name (e.g. us-west-2).
        /// </para>
        /// <para>
        /// This parameter can also be used to return AWSRegion instances for the US GovCloud and China (Beijing)
        /// regions by specifying the relevant system name.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipeline = true, ParameterSetName = DefaultParameterSet)]
        [Parameter(ParameterSetName = PublicAndGovCloudParameterSet)]
        public string SystemName { get; set; }

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
        [Parameter(ParameterSetName = DefaultParameterSet)]
        [Parameter(ParameterSetName = PublicAndGovCloudParameterSet)]
        public SwitchParameter IncludeChina { get; set; }

        /// <summary>
        /// <para>If set the returned collection includes 'Gov Cloud' region(s).</para>
        /// <para>Default: off.</para>
        /// </summary>
        [Parameter(ParameterSetName = PublicAndGovCloudParameterSet)]
        public SwitchParameter IncludeGovCloud { get; set; }

        /// <summary>
        /// <para>If set the returned collection contains only the 'Gov Cloud' region(s).</para>
        /// <para>Default: off.</para>
        /// </summary>
        [Parameter(ParameterSetName = GovCloudOnlyParameterSet)]
        public SwitchParameter GovCloudOnly { get; set; }

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
