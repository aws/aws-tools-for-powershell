/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Omics;
using Amazon.Omics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Create a new configuration.
    /// </summary>
    [Cmdlet("New", "OMICSConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateConfiguration API operation.", Operation = new[] {"CreateConfiguration"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateConfigurationResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateConfigurationResponse object containing multiple properties."
    )]
    public partial class NewOMICSConfigurationCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Optional description for the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>User-friendly name for the configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>Optional request idempotency token. If not specified, a universally unique identifier
        /// (UUID) will be automatically generated for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter RunConfigurations_VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>List of security group IDs. Maximum of 5 security groups allowed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RunConfigurations_VpcConfig_SecurityGroupIds")]
        public System.String[] RunConfigurations_VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter RunConfigurations_VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>List of subnet IDs. Maximum of 16 subnets allowed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RunConfigurations_VpcConfig_SubnetIds")]
        public System.String[] RunConfigurations_VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional tags for the configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateConfigurationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSConfiguration (CreateConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateConfigurationResponse, NewOMICSConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RequestId = this.RequestId;
            if (this.RunConfigurations_VpcConfig_SecurityGroupId != null)
            {
                context.RunConfigurations_VpcConfig_SecurityGroupId = new List<System.String>(this.RunConfigurations_VpcConfig_SecurityGroupId);
            }
            if (this.RunConfigurations_VpcConfig_SubnetId != null)
            {
                context.RunConfigurations_VpcConfig_SubnetId = new List<System.String>(this.RunConfigurations_VpcConfig_SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.Omics.Model.CreateConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            
             // populate RunConfigurations
            var requestRunConfigurationsIsNull = true;
            request.RunConfigurations = new Amazon.Omics.Model.RunConfigurations();
            Amazon.Omics.Model.VpcConfig requestRunConfigurations_runConfigurations_VpcConfig = null;
            
             // populate VpcConfig
            var requestRunConfigurations_runConfigurations_VpcConfigIsNull = true;
            requestRunConfigurations_runConfigurations_VpcConfig = new Amazon.Omics.Model.VpcConfig();
            List<System.String> requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SecurityGroupId = null;
            if (cmdletContext.RunConfigurations_VpcConfig_SecurityGroupId != null)
            {
                requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SecurityGroupId = cmdletContext.RunConfigurations_VpcConfig_SecurityGroupId;
            }
            if (requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SecurityGroupId != null)
            {
                requestRunConfigurations_runConfigurations_VpcConfig.SecurityGroupIds = requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SecurityGroupId;
                requestRunConfigurations_runConfigurations_VpcConfigIsNull = false;
            }
            List<System.String> requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SubnetId = null;
            if (cmdletContext.RunConfigurations_VpcConfig_SubnetId != null)
            {
                requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SubnetId = cmdletContext.RunConfigurations_VpcConfig_SubnetId;
            }
            if (requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SubnetId != null)
            {
                requestRunConfigurations_runConfigurations_VpcConfig.SubnetIds = requestRunConfigurations_runConfigurations_VpcConfig_runConfigurations_VpcConfig_SubnetId;
                requestRunConfigurations_runConfigurations_VpcConfigIsNull = false;
            }
             // determine if requestRunConfigurations_runConfigurations_VpcConfig should be set to null
            if (requestRunConfigurations_runConfigurations_VpcConfigIsNull)
            {
                requestRunConfigurations_runConfigurations_VpcConfig = null;
            }
            if (requestRunConfigurations_runConfigurations_VpcConfig != null)
            {
                request.RunConfigurations.VpcConfig = requestRunConfigurations_runConfigurations_VpcConfig;
                requestRunConfigurationsIsNull = false;
            }
             // determine if request.RunConfigurations should be set to null
            if (requestRunConfigurationsIsNull)
            {
                request.RunConfigurations = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Omics.Model.CreateConfigurationResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateConfiguration");
            try
            {
                return client.CreateConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            public List<System.String> RunConfigurations_VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> RunConfigurations_VpcConfig_SubnetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Omics.Model.CreateConfigurationResponse, NewOMICSConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
