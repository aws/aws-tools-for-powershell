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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates a new configuration recorder to record the selected resource configurations.
    /// 
    ///  
    /// <para>
    /// You can use this action to change the role <code>roleARN</code> or the <code>recordingGroup</code>
    /// of an existing recorder. To change the role, call the action on the existing configuration
    /// recorder and specify a role.
    /// </para><note><para>
    /// Currently, you can specify only one configuration recorder per region in your account.
    /// </para><para>
    /// If <code>ConfigurationRecorder</code> does not have the <b>recordingGroup</b> parameter
    /// specified, the default is to record all supported resource types.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConfigurationRecorder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Config PutConfigurationRecorder API operation.", Operation = new[] {"PutConfigurationRecorder"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutConfigurationRecorderResponse))]
    [AWSCmdletOutput("None or Amazon.ConfigService.Model.PutConfigurationRecorderResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConfigService.Model.PutConfigurationRecorderResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGConfigurationRecorderCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter RecordingGroup_AllSupported
        /// <summary>
        /// <para>
        /// <para>Specifies whether Config records configuration changes for every supported type of
        /// regional resource.</para><para>If you set this option to <code>true</code>, when Config adds support for a new type
        /// of regional resource, it starts recording resources of that type automatically.</para><para>If you set this option to <code>true</code>, you cannot enumerate a list of <code>resourceTypes</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_AllSupported")]
        public System.Boolean? RecordingGroup_AllSupported { get; set; }
        #endregion
        
        #region Parameter RecordingGroup_IncludeGlobalResourceType
        /// <summary>
        /// <para>
        /// <para>Specifies whether Config includes all supported types of global resources (for example,
        /// IAM resources) with the resources that it records.</para><para>Before you can set this option to <code>true</code>, you must set the <code>allSupported</code>
        /// option to <code>true</code>.</para><para>If you set this option to <code>true</code>, when Config adds support for a new type
        /// of global resource, it starts recording resources of that type automatically.</para><para>The configuration details for any global resource are the same in all regions. To
        /// prevent duplicate configuration items, you should consider customizing Config in only
        /// one region to record global resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_IncludeGlobalResourceTypes")]
        public System.Boolean? RecordingGroup_IncludeGlobalResourceType { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorderName
        /// <summary>
        /// <para>
        /// <para>The name of the recorder. By default, Config automatically assigns the name "default"
        /// when creating the configuration recorder. You cannot change the assigned name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ConfigurationRecorder_Name")]
        public System.String ConfigurationRecorderName { get; set; }
        #endregion
        
        #region Parameter RecordingGroup_ResourceType
        /// <summary>
        /// <para>
        /// <para>A comma-separated list that specifies the types of Amazon Web Services resources for
        /// which Config records configuration changes (for example, <code>AWS::EC2::Instance</code>
        /// or <code>AWS::CloudTrail::Trail</code>).</para><para>To record all configuration changes, you must set the <code>allSupported</code> option
        /// to <code>true</code>.</para><para>If you set the <code>AllSupported</code> option to false and populate the <code>ResourceTypes</code>
        /// option with values, when Config adds support for a new type of resource, it will not
        /// record resources of that type unless you manually add that type to your recording
        /// group.</para><para>For a list of valid <code>resourceTypes</code> values, see the <b>resourceType Value</b>
        /// column in <a href="https://docs.aws.amazon.com/config/latest/developerguide/resource-config-reference.html#supported-resources">Supported
        /// Amazon Web Services resource Types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_ResourceTypes")]
        public System.String[] RecordingGroup_ResourceType { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorder_RoleARN
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the IAM role used to describe the Amazon Web Services
        /// resources associated with the account.</para><note><para>While the API model does not require this field, the server will reject a request
        /// without a defined roleARN for the configuration recorder.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationRecorder_RoleARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutConfigurationRecorderResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationRecorderName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationRecorderName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationRecorderName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationRecorderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConfigurationRecorder (PutConfigurationRecorder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutConfigurationRecorderResponse, WriteCFGConfigurationRecorderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationRecorderName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigurationRecorderName = this.ConfigurationRecorderName;
            context.RecordingGroup_AllSupported = this.RecordingGroup_AllSupported;
            context.RecordingGroup_IncludeGlobalResourceType = this.RecordingGroup_IncludeGlobalResourceType;
            if (this.RecordingGroup_ResourceType != null)
            {
                context.RecordingGroup_ResourceType = new List<System.String>(this.RecordingGroup_ResourceType);
            }
            context.ConfigurationRecorder_RoleARN = this.ConfigurationRecorder_RoleARN;
            
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
            var request = new Amazon.ConfigService.Model.PutConfigurationRecorderRequest();
            
            
             // populate ConfigurationRecorder
            var requestConfigurationRecorderIsNull = true;
            request.ConfigurationRecorder = new Amazon.ConfigService.Model.ConfigurationRecorder();
            System.String requestConfigurationRecorder_configurationRecorderName = null;
            if (cmdletContext.ConfigurationRecorderName != null)
            {
                requestConfigurationRecorder_configurationRecorderName = cmdletContext.ConfigurationRecorderName;
            }
            if (requestConfigurationRecorder_configurationRecorderName != null)
            {
                request.ConfigurationRecorder.Name = requestConfigurationRecorder_configurationRecorderName;
                requestConfigurationRecorderIsNull = false;
            }
            System.String requestConfigurationRecorder_configurationRecorder_RoleARN = null;
            if (cmdletContext.ConfigurationRecorder_RoleARN != null)
            {
                requestConfigurationRecorder_configurationRecorder_RoleARN = cmdletContext.ConfigurationRecorder_RoleARN;
            }
            if (requestConfigurationRecorder_configurationRecorder_RoleARN != null)
            {
                request.ConfigurationRecorder.RoleARN = requestConfigurationRecorder_configurationRecorder_RoleARN;
                requestConfigurationRecorderIsNull = false;
            }
            Amazon.ConfigService.Model.RecordingGroup requestConfigurationRecorder_configurationRecorder_RecordingGroup = null;
            
             // populate RecordingGroup
            var requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = true;
            requestConfigurationRecorder_configurationRecorder_RecordingGroup = new Amazon.ConfigService.Model.RecordingGroup();
            System.Boolean? requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported = null;
            if (cmdletContext.RecordingGroup_AllSupported != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported = cmdletContext.RecordingGroup_AllSupported.Value;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.AllSupported = requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported.Value;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
            System.Boolean? requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType = null;
            if (cmdletContext.RecordingGroup_IncludeGlobalResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType = cmdletContext.RecordingGroup_IncludeGlobalResourceType.Value;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.IncludeGlobalResourceTypes = requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType.Value;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
            List<System.String> requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType = null;
            if (cmdletContext.RecordingGroup_ResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType = cmdletContext.RecordingGroup_ResourceType;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.ResourceTypes = requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
             // determine if requestConfigurationRecorder_configurationRecorder_RecordingGroup should be set to null
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup = null;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup != null)
            {
                request.ConfigurationRecorder.RecordingGroup = requestConfigurationRecorder_configurationRecorder_RecordingGroup;
                requestConfigurationRecorderIsNull = false;
            }
             // determine if request.ConfigurationRecorder should be set to null
            if (requestConfigurationRecorderIsNull)
            {
                request.ConfigurationRecorder = null;
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
        
        private Amazon.ConfigService.Model.PutConfigurationRecorderResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutConfigurationRecorderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutConfigurationRecorder");
            try
            {
                #if DESKTOP
                return client.PutConfigurationRecorder(request);
                #elif CORECLR
                return client.PutConfigurationRecorderAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationRecorderName { get; set; }
            public System.Boolean? RecordingGroup_AllSupported { get; set; }
            public System.Boolean? RecordingGroup_IncludeGlobalResourceType { get; set; }
            public List<System.String> RecordingGroup_ResourceType { get; set; }
            public System.String ConfigurationRecorder_RoleARN { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutConfigurationRecorderResponse, WriteCFGConfigurationRecorderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
