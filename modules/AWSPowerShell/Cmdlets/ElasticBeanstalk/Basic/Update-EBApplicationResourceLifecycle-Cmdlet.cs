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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Modifies lifecycle settings for an application.
    /// </summary>
    [Cmdlet("Update", "EBApplicationResourceLifecycle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk UpdateApplicationResourceLifecycle API operation.", Operation = new[] {"UpdateApplicationResourceLifecycle"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse object containing multiple properties."
    )]
    public partial class UpdateEBApplicationResourceLifecycleCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter MaxAgeRule_DeleteSourceFromS3
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to delete a version's source bundle from Amazon S3 when Elastic
        /// Beanstalk deletes the application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_DeleteSourceFromS3")]
        public System.Boolean? MaxAgeRule_DeleteSourceFromS3 { get; set; }
        #endregion
        
        #region Parameter MaxCountRule_DeleteSourceFromS3
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to delete a version's source bundle from Amazon S3 when Elastic
        /// Beanstalk deletes the application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_DeleteSourceFromS3")]
        public System.Boolean? MaxCountRule_DeleteSourceFromS3 { get; set; }
        #endregion
        
        #region Parameter MaxAgeRule_Enabled
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to apply the rule, or <c>false</c> to disable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_Enabled")]
        public System.Boolean? MaxAgeRule_Enabled { get; set; }
        #endregion
        
        #region Parameter MaxCountRule_Enabled
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to apply the rule, or <c>false</c> to disable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_Enabled")]
        public System.Boolean? MaxCountRule_Enabled { get; set; }
        #endregion
        
        #region Parameter MaxAgeRule_MaxAgeInDay
        /// <summary>
        /// <para>
        /// <para>Specify the number of days to retain an application versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_MaxAgeInDays")]
        public System.Int32? MaxAgeRule_MaxAgeInDay { get; set; }
        #endregion
        
        #region Parameter MaxCountRule_MaxCount
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of application versions to retain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_MaxCount")]
        public System.Int32? MaxCountRule_MaxCount { get; set; }
        #endregion
        
        #region Parameter ResourceLifecycleConfig_ServiceRole
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM service role that Elastic Beanstalk has permission to assume.</para><para>The <c>ServiceRole</c> property is required the first time that you provide a <c>VersionLifecycleConfig</c>
        /// for the application in one of the supporting calls (<c>CreateApplication</c> or <c>UpdateApplicationResourceLifecycle</c>).
        /// After you provide it once, in either one of the calls, Elastic Beanstalk persists
        /// the Service Role with the application, and you don't need to specify it again in subsequent
        /// <c>UpdateApplicationResourceLifecycle</c> calls. You can, however, specify it in subsequent
        /// calls to change the Service Role to another value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceLifecycleConfig_ServiceRole { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EBApplicationResourceLifecycle (UpdateApplicationResourceLifecycle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse, UpdateEBApplicationResourceLifecycleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceLifecycleConfig_ServiceRole = this.ResourceLifecycleConfig_ServiceRole;
            context.MaxAgeRule_DeleteSourceFromS3 = this.MaxAgeRule_DeleteSourceFromS3;
            context.MaxAgeRule_Enabled = this.MaxAgeRule_Enabled;
            context.MaxAgeRule_MaxAgeInDay = this.MaxAgeRule_MaxAgeInDay;
            context.MaxCountRule_DeleteSourceFromS3 = this.MaxCountRule_DeleteSourceFromS3;
            context.MaxCountRule_Enabled = this.MaxCountRule_Enabled;
            context.MaxCountRule_MaxCount = this.MaxCountRule_MaxCount;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate ResourceLifecycleConfig
            var requestResourceLifecycleConfigIsNull = true;
            request.ResourceLifecycleConfig = new Amazon.ElasticBeanstalk.Model.ApplicationResourceLifecycleConfig();
            System.String requestResourceLifecycleConfig_resourceLifecycleConfig_ServiceRole = null;
            if (cmdletContext.ResourceLifecycleConfig_ServiceRole != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_ServiceRole = cmdletContext.ResourceLifecycleConfig_ServiceRole;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_ServiceRole != null)
            {
                request.ResourceLifecycleConfig.ServiceRole = requestResourceLifecycleConfig_resourceLifecycleConfig_ServiceRole;
                requestResourceLifecycleConfigIsNull = false;
            }
            Amazon.ElasticBeanstalk.Model.ApplicationVersionLifecycleConfig requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig = null;
            
             // populate VersionLifecycleConfig
            var requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfigIsNull = true;
            requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig = new Amazon.ElasticBeanstalk.Model.ApplicationVersionLifecycleConfig();
            Amazon.ElasticBeanstalk.Model.MaxAgeRule requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule = null;
            
             // populate MaxAgeRule
            var requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull = true;
            requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule = new Amazon.ElasticBeanstalk.Model.MaxAgeRule();
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3 = null;
            if (cmdletContext.MaxAgeRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3 = cmdletContext.MaxAgeRule_DeleteSourceFromS3.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule.DeleteSourceFromS3 = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull = false;
            }
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled = null;
            if (cmdletContext.MaxAgeRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled = cmdletContext.MaxAgeRule_Enabled.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule.Enabled = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull = false;
            }
            System.Int32? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_MaxAgeInDay = null;
            if (cmdletContext.MaxAgeRule_MaxAgeInDay != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_MaxAgeInDay = cmdletContext.MaxAgeRule_MaxAgeInDay.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_MaxAgeInDay != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule.MaxAgeInDays = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_MaxAgeInDay.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull = false;
            }
             // determine if requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule should be set to null
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule = null;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig.MaxAgeRule = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfigIsNull = false;
            }
            Amazon.ElasticBeanstalk.Model.MaxCountRule requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule = null;
            
             // populate MaxCountRule
            var requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull = true;
            requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule = new Amazon.ElasticBeanstalk.Model.MaxCountRule();
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3 = null;
            if (cmdletContext.MaxCountRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3 = cmdletContext.MaxCountRule_DeleteSourceFromS3.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule.DeleteSourceFromS3 = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull = false;
            }
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled = null;
            if (cmdletContext.MaxCountRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled = cmdletContext.MaxCountRule_Enabled.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule.Enabled = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull = false;
            }
            System.Int32? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_MaxCount = null;
            if (cmdletContext.MaxCountRule_MaxCount != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_MaxCount = cmdletContext.MaxCountRule_MaxCount.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_MaxCount != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule.MaxCount = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_MaxCount.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull = false;
            }
             // determine if requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule should be set to null
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule = null;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig.MaxCountRule = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfigIsNull = false;
            }
             // determine if requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig should be set to null
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfigIsNull)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig = null;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig != null)
            {
                request.ResourceLifecycleConfig.VersionLifecycleConfig = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig;
                requestResourceLifecycleConfigIsNull = false;
            }
             // determine if request.ResourceLifecycleConfig should be set to null
            if (requestResourceLifecycleConfigIsNull)
            {
                request.ResourceLifecycleConfig = null;
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
        
        private Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "UpdateApplicationResourceLifecycle");
            try
            {
                #if DESKTOP
                return client.UpdateApplicationResourceLifecycle(request);
                #elif CORECLR
                return client.UpdateApplicationResourceLifecycleAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.String ResourceLifecycleConfig_ServiceRole { get; set; }
            public System.Boolean? MaxAgeRule_DeleteSourceFromS3 { get; set; }
            public System.Boolean? MaxAgeRule_Enabled { get; set; }
            public System.Int32? MaxAgeRule_MaxAgeInDay { get; set; }
            public System.Boolean? MaxCountRule_DeleteSourceFromS3 { get; set; }
            public System.Boolean? MaxCountRule_Enabled { get; set; }
            public System.Int32? MaxCountRule_MaxCount { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.UpdateApplicationResourceLifecycleResponse, UpdateEBApplicationResourceLifecycleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
