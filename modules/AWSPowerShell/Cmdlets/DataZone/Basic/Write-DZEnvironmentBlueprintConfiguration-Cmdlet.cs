/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Writes the configuration for the specified environment blueprint in Amazon DataZone.
    /// </summary>
    [Cmdlet("Write", "DZEnvironmentBlueprintConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon DataZone PutEnvironmentBlueprintConfiguration API operation.", Operation = new[] {"PutEnvironmentBlueprintConfiguration"}, SelectReturnType = typeof(Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse",
        "This cmdlet returns an Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteDZEnvironmentBlueprintConfigurationCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone domain.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter EnabledRegion
        /// <summary>
        /// <para>
        /// <para>Specifies the enabled Amazon Web Services Regions.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EnabledRegions")]
        public System.String[] EnabledRegion { get; set; }
        #endregion
        
        #region Parameter EnvironmentBlueprintIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the environment blueprint.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EnvironmentBlueprintIdentifier { get; set; }
        #endregion
        
        #region Parameter ManageAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the manage access role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManageAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter ProvisioningConfiguration
        /// <summary>
        /// <para>
        /// <para>The provisioning configuration of a blueprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisioningConfigurations")]
        public Amazon.DataZone.Model.ProvisioningConfiguration[] ProvisioningConfiguration { get; set; }
        #endregion
        
        #region Parameter ProvisioningRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the provisioning role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningRoleArn { get; set; }
        #endregion
        
        #region Parameter RegionalParameter
        /// <summary>
        /// <para>
        /// <para>The regional parameters in the environment blueprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RegionalParameters")]
        public System.Collections.Hashtable RegionalParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentBlueprintIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-DZEnvironmentBlueprintConfiguration (PutEnvironmentBlueprintConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse, WriteDZEnvironmentBlueprintConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EnabledRegion != null)
            {
                context.EnabledRegion = new List<System.String>(this.EnabledRegion);
            }
            #if MODULAR
            if (this.EnabledRegion == null && ParameterWasBound(nameof(this.EnabledRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter EnabledRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentBlueprintIdentifier = this.EnvironmentBlueprintIdentifier;
            #if MODULAR
            if (this.EnvironmentBlueprintIdentifier == null && ParameterWasBound(nameof(this.EnvironmentBlueprintIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentBlueprintIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManageAccessRoleArn = this.ManageAccessRoleArn;
            if (this.ProvisioningConfiguration != null)
            {
                context.ProvisioningConfiguration = new List<Amazon.DataZone.Model.ProvisioningConfiguration>(this.ProvisioningConfiguration);
            }
            context.ProvisioningRoleArn = this.ProvisioningRoleArn;
            if (this.RegionalParameter != null)
            {
                context.RegionalParameter = new Dictionary<System.String, Dictionary<System.String, System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.RegionalParameter.Keys)
                {
                    context.RegionalParameter.Add((String)hashKey, (Dictionary<System.String,System.String>)(this.RegionalParameter[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationRequest();
            
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EnabledRegion != null)
            {
                request.EnabledRegions = cmdletContext.EnabledRegion;
            }
            if (cmdletContext.EnvironmentBlueprintIdentifier != null)
            {
                request.EnvironmentBlueprintIdentifier = cmdletContext.EnvironmentBlueprintIdentifier;
            }
            if (cmdletContext.ManageAccessRoleArn != null)
            {
                request.ManageAccessRoleArn = cmdletContext.ManageAccessRoleArn;
            }
            if (cmdletContext.ProvisioningConfiguration != null)
            {
                request.ProvisioningConfigurations = cmdletContext.ProvisioningConfiguration;
            }
            if (cmdletContext.ProvisioningRoleArn != null)
            {
                request.ProvisioningRoleArn = cmdletContext.ProvisioningRoleArn;
            }
            if (cmdletContext.RegionalParameter != null)
            {
                request.RegionalParameters = cmdletContext.RegionalParameter;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "PutEnvironmentBlueprintConfiguration");
            try
            {
                #if DESKTOP
                return client.PutEnvironmentBlueprintConfiguration(request);
                #elif CORECLR
                return client.PutEnvironmentBlueprintConfigurationAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String DomainIdentifier { get; set; }
            public List<System.String> EnabledRegion { get; set; }
            public System.String EnvironmentBlueprintIdentifier { get; set; }
            public System.String ManageAccessRoleArn { get; set; }
            public List<Amazon.DataZone.Model.ProvisioningConfiguration> ProvisioningConfiguration { get; set; }
            public System.String ProvisioningRoleArn { get; set; }
            public Dictionary<System.String, Dictionary<System.String, System.String>> RegionalParameter { get; set; }
            public System.Func<Amazon.DataZone.Model.PutEnvironmentBlueprintConfigurationResponse, WriteDZEnvironmentBlueprintConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
