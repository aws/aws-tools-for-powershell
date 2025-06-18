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
    /// Creates an <i>investigation group</i> in your account. Creating an investigation group
    /// is a one-time setup task for each Region in your account. It is a necessary task to
    /// be able to perform investigations.
    /// 
    ///  
    /// <para>
    /// Settings in the investigation group help you centrally manage the common properties
    /// of your investigations, such as the following:
    /// </para><ul><li><para>
    /// Who can access the investigations
    /// </para></li><li><para>
    /// Whether investigation data is encrypted with a customer managed Key Management Service
    /// key.
    /// </para></li><li><para>
    /// How long investigations and their data are retained by default.
    /// </para></li></ul><para>
    /// Currently, you can have one investigation group in each Region in your account. Each
    /// investigation in a Region is a part of the investigation group in that Region
    /// </para><para>
    /// To create an investigation group and set up Amazon Q Developer operational investigations,
    /// you must be signed in to an IAM principal that has the either the <c>AIOpsConsoleAdminPolicy</c>
    /// or the <c>AdministratorAccess</c> IAM policy attached, or to an account that has similar
    /// permissions.
    /// </para><important><para>
    /// You can configure CloudWatch alarms to start investigations and add events to investigations.
    /// If you create your investigation group with <c>CreateInvestigationGroup</c> and you
    /// want to enable alarms to do this, you must use <a href="https://docs.aws.amazon.com/operationalinvestigations/latest/AmazonQDeveloperOperationalInvestigationsAPIReference/API_PutInvestigationGroupPolicy.html">PutInvestigationGroupPolicy</a>
    /// to create a resource policy that grants this permission to CloudWatch alarms. 
    /// </para><para>
    /// For more information about configuring CloudWatch alarms to work with Amazon Q Developer
    /// operational investigations, see 
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "AIOpsInvestigationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS AI Ops CreateInvestigationGroup API operation.", Operation = new[] {"CreateInvestigationGroup"}, SelectReturnType = typeof(Amazon.AIOps.Model.CreateInvestigationGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.AIOps.Model.CreateInvestigationGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AIOps.Model.CreateInvestigationGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAIOpsInvestigationGroupCmdlet : AmazonAIOpsClientCmdlet, IExecutor
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the investigation group.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RetentionInDay
        /// <summary>
        /// <para>
        /// <para>Specify how long that investigation data is kept. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Investigations-Retention.html">Operational
        /// investigation data retention</a>. </para><para>If you omit this parameter, the default of 90 days is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionInDays")]
        public System.Int64? RetentionInDay { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>Specify the ARN of the IAM role that Amazon Q Developer operational investigations
        /// will use when it gathers investigation data. The permissions in this role determine
        /// which of your resources that Amazon Q Developer operational investigations will have
        /// access to during investigations.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Investigations-Security.html#Investigations-Security-Data">How
        /// to control what data Amazon Q has access to during investigations</a>.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the investigation group. You can associate
        /// as many as 50 tags with an investigation group. To be able to associate tags when
        /// you create the investigation group, you must have the <c>cloudwatch:TagResource</c>
        /// permission.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AIOps.Model.CreateInvestigationGroupResponse).
        /// Specifying the name of a property of type Amazon.AIOps.Model.CreateInvestigationGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AIOpsInvestigationGroup (CreateInvestigationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AIOps.Model.CreateInvestigationGroupResponse, NewAIOpsInvestigationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.IsCloudTrailEventHistoryEnabled = this.IsCloudTrailEventHistoryEnabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionInDay = this.RetentionInDay;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagKeyBoundary != null)
            {
                context.TagKeyBoundary = new List<System.String>(this.TagKeyBoundary);
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
            var request = new Amazon.AIOps.Model.CreateInvestigationGroupRequest();
            
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
            if (cmdletContext.IsCloudTrailEventHistoryEnabled != null)
            {
                request.IsCloudTrailEventHistoryEnabled = cmdletContext.IsCloudTrailEventHistoryEnabled.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RetentionInDay != null)
            {
                request.RetentionInDays = cmdletContext.RetentionInDay.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.TagKeyBoundary != null)
            {
                request.TagKeyBoundaries = cmdletContext.TagKeyBoundary;
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
        
        private Amazon.AIOps.Model.CreateInvestigationGroupResponse CallAWSServiceOperation(IAmazonAIOps client, Amazon.AIOps.Model.CreateInvestigationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AI Ops", "CreateInvestigationGroup");
            try
            {
                #if DESKTOP
                return client.CreateInvestigationGroup(request);
                #elif CORECLR
                return client.CreateInvestigationGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IsCloudTrailEventHistoryEnabled { get; set; }
            public System.String Name { get; set; }
            public System.Int64? RetentionInDay { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> TagKeyBoundary { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AIOps.Model.CreateInvestigationGroupResponse, NewAIOpsInvestigationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
