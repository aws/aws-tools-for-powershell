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
using Amazon.AIOps;
using Amazon.AIOps.Model;

namespace Amazon.PowerShell.Cmdlets.AIOps
{
    /// <summary>
    /// Updates the configuration of the specified investigation group.
    /// </summary>
    [Cmdlet("Update", "AIOpsInvestigationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS AI Ops UpdateInvestigationGroup API operation.", Operation = new[] {"UpdateInvestigationGroup"}, SelectReturnType = typeof(Amazon.AIOps.Model.UpdateInvestigationGroupResponse))]
    [AWSCmdletOutput("None or Amazon.AIOps.Model.UpdateInvestigationGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AIOps.Model.UpdateInvestigationGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateAIOpsInvestigationGroupCmdlet : AmazonAIOpsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChatbotNotificationChannel
        /// <summary>
        /// <para>
        /// <para>Use this structure to integrate Amazon Q Developer operational investigations with
        /// Amazon Q in chat applications. This structure is a string array. For the first string,
        /// specify the ARN of an Amazon SNS topic. For the array of strings, specify the ARNs
        /// of one or more Amazon Q in chat applications configurations that you want to associate
        /// with that topic. For more information about these configuration ARNs, see <a href="https://docs.aws.amazon.com/chatbot/latest/adminguide/getting-started.html">Getting
        /// started with Amazon Q in chat applications</a> and <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awschatbot.html#awschatbot-resources-for-iam-policies">Resource
        /// type defined by Amazon Web Services Chatbot</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ChatbotNotificationChannel { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>Specify either the name or the ARN of the investigation group that you want to modify.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter IsCloudTrailEventHistoryEnabled
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to enable Amazon Q Developer operational investigations to have
        /// access to change events that are recorded by CloudTrail. The default is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsCloudTrailEventHistoryEnabled { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>If the investigation group uses a customer managed key for encryption, this field
        /// displays the ID of that key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>Specify this field if you want to change the IAM role that Amazon Q Developer operational
        /// investigations will use when it gathers investigation data. To do so, specify the
        /// ARN of the new role.</para><para>The permissions in this role determine which of your resources that Amazon Q Developer
        /// operational investigations will have access to during investigations.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Investigations-Security.html#Investigations-Security-Data">EHow
        /// to control what data Amazon Q has access to during investigations</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter TagKeyBoundary
        /// <summary>
        /// <para>
        /// <para>Enter the existing custom tag keys for custom applications in your system. Resource
        /// tags help Amazon Q narrow the search space when it is unable to discover definite
        /// relationships between resources. For example, to discover that an Amazon ECS service
        /// depends on an Amazon RDS database, Amazon Q can discover this relationship using data
        /// sources such as X-Ray and CloudWatch Application Signals. However, if you haven't
        /// deployed these features, Amazon Q will attempt to identify possible relationships.
        /// Tag boundaries can be used to narrow the resources that will be discovered by Amazon
        /// Q in these cases.</para><para>You don't need to enter tags created by myApplications or CloudFormation, because
        /// Amazon Q can automatically detect those tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagKeyBoundaries")]
        public System.String[] TagKeyBoundary { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>Displays whether investigation data is encrypted by a customer managed key or an Amazon
        /// Web Services owned kay.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AIOps.EncryptionConfigurationType")]
        public Amazon.AIOps.EncryptionConfigurationType EncryptionConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AIOps.Model.UpdateInvestigationGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AIOpsInvestigationGroup (UpdateInvestigationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AIOps.Model.UpdateInvestigationGroupResponse, UpdateAIOpsInvestigationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ChatbotNotificationChannel != null)
            {
                context.ChatbotNotificationChannel = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ChatbotNotificationChannel.Keys)
                {
                    object hashValue = this.ChatbotNotificationChannel[hashKey];
                    if (hashValue == null)
                    {
                        context.ChatbotNotificationChannel.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.ChatbotNotificationChannel.Add((String)hashKey, valueSet);
                }
            }
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsCloudTrailEventHistoryEnabled = this.IsCloudTrailEventHistoryEnabled;
            context.RoleArn = this.RoleArn;
            if (this.TagKeyBoundary != null)
            {
                context.TagKeyBoundary = new List<System.String>(this.TagKeyBoundary);
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
            var request = new Amazon.AIOps.Model.UpdateInvestigationGroupRequest();
            
            if (cmdletContext.ChatbotNotificationChannel != null)
            {
                request.ChatbotNotificationChannel = cmdletContext.ChatbotNotificationChannel;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.AIOps.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.AIOps.EncryptionConfigurationType requestEncryptionConfiguration_encryptionConfiguration_Type = null;
            if (cmdletContext.EncryptionConfiguration_Type != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Type = cmdletContext.EncryptionConfiguration_Type;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Type != null)
            {
                request.EncryptionConfiguration.Type = requestEncryptionConfiguration_encryptionConfiguration_Type;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.IsCloudTrailEventHistoryEnabled != null)
            {
                request.IsCloudTrailEventHistoryEnabled = cmdletContext.IsCloudTrailEventHistoryEnabled.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.TagKeyBoundary != null)
            {
                request.TagKeyBoundaries = cmdletContext.TagKeyBoundary;
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
        
        private Amazon.AIOps.Model.UpdateInvestigationGroupResponse CallAWSServiceOperation(IAmazonAIOps client, Amazon.AIOps.Model.UpdateInvestigationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AI Ops", "UpdateInvestigationGroup");
            try
            {
                #if DESKTOP
                return client.UpdateInvestigationGroup(request);
                #elif CORECLR
                return client.UpdateInvestigationGroupAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<System.String>> ChatbotNotificationChannel { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public Amazon.AIOps.EncryptionConfigurationType EncryptionConfiguration_Type { get; set; }
            public System.String Identifier { get; set; }
            public System.Boolean? IsCloudTrailEventHistoryEnabled { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> TagKeyBoundary { get; set; }
            public System.Func<Amazon.AIOps.Model.UpdateInvestigationGroupResponse, UpdateAIOpsInvestigationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
