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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Creates an application that has one configuration template named <code>default</code>
    /// and no application versions.
    /// </summary>
    [Cmdlet("New", "EBApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.ApplicationDescription")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk CreateApplication API operation.", Operation = new[] {"CreateApplication"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.ApplicationDescription",
        "This cmdlet returns a ApplicationDescription object.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.CreateApplicationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEBApplicationCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para><para>Constraint: This name must be unique within your account. If the specified name already
        /// exists, the action returns an <code>InvalidParameterValue</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter MaxAgeRule_DeleteSourceFromS3
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to delete a version's source bundle from Amazon S3 when Elastic
        /// Beanstalk deletes the application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_DeleteSourceFromS3")]
        public System.Boolean MaxAgeRule_DeleteSourceFromS3 { get; set; }
        #endregion
        
        #region Parameter MaxCountRule_DeleteSourceFromS3
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to delete a version's source bundle from Amazon S3 when Elastic
        /// Beanstalk deletes the application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_DeleteSourceFromS3")]
        public System.Boolean MaxCountRule_DeleteSourceFromS3 { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Describes the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MaxAgeRule_Enabled
        /// <summary>
        /// <para>
        /// <para>Specify <code>true</code> to apply the rule, or <code>false</code> to disable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_Enabled")]
        public System.Boolean MaxAgeRule_Enabled { get; set; }
        #endregion
        
        #region Parameter MaxCountRule_Enabled
        /// <summary>
        /// <para>
        /// <para>Specify <code>true</code> to apply the rule, or <code>false</code> to disable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_Enabled")]
        public System.Boolean MaxCountRule_Enabled { get; set; }
        #endregion
        
        #region Parameter MaxAgeRule_MaxAgeInDay
        /// <summary>
        /// <para>
        /// <para>Specify the number of days to retain an application versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_MaxAgeInDays")]
        public System.Int32 MaxAgeRule_MaxAgeInDay { get; set; }
        #endregion
        
        #region Parameter MaxCountRule_MaxCount
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of application versions to retain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_MaxCount")]
        public System.Int32 MaxCountRule_MaxCount { get; set; }
        #endregion
        
        #region Parameter ResourceLifecycleConfig_ServiceRole
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM service role that Elastic Beanstalk has permission to assume.</para><para>The <code>ServiceRole</code> property is required the first time that you provide
        /// a <code>VersionLifecycleConfig</code> for the application in one of the supporting
        /// calls (<code>CreateApplication</code> or <code>UpdateApplicationResourceLifecycle</code>).
        /// After you provide it once, in either one of the calls, Elastic Beanstalk persists
        /// the Service Role with the application, and you don't need to specify it again in subsequent
        /// <code>UpdateApplicationResourceLifecycle</code> calls. You can, however, specify it
        /// in subsequent calls to change the Service Role to another value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceLifecycleConfig_ServiceRole { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationName = this.ApplicationName;
            context.Description = this.Description;
            context.ResourceLifecycleConfig_ServiceRole = this.ResourceLifecycleConfig_ServiceRole;
            if (ParameterWasBound("MaxAgeRule_DeleteSourceFromS3"))
                context.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_DeleteSourceFromS3 = this.MaxAgeRule_DeleteSourceFromS3;
            if (ParameterWasBound("MaxAgeRule_Enabled"))
                context.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_Enabled = this.MaxAgeRule_Enabled;
            if (ParameterWasBound("MaxAgeRule_MaxAgeInDay"))
                context.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_MaxAgeInDays = this.MaxAgeRule_MaxAgeInDay;
            if (ParameterWasBound("MaxCountRule_DeleteSourceFromS3"))
                context.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_DeleteSourceFromS3 = this.MaxCountRule_DeleteSourceFromS3;
            if (ParameterWasBound("MaxCountRule_Enabled"))
                context.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_Enabled = this.MaxCountRule_Enabled;
            if (ParameterWasBound("MaxCountRule_MaxCount"))
                context.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_MaxCount = this.MaxCountRule_MaxCount;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.CreateApplicationRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ResourceLifecycleConfig
            bool requestResourceLifecycleConfigIsNull = true;
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
            bool requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfigIsNull = true;
            requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig = new Amazon.ElasticBeanstalk.Model.ApplicationVersionLifecycleConfig();
            Amazon.ElasticBeanstalk.Model.MaxAgeRule requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule = null;
            
             // populate MaxAgeRule
            bool requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull = true;
            requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule = new Amazon.ElasticBeanstalk.Model.MaxAgeRule();
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3 = null;
            if (cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3 = cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_DeleteSourceFromS3.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule.DeleteSourceFromS3 = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_DeleteSourceFromS3.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull = false;
            }
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled = null;
            if (cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled = cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_Enabled.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule.Enabled = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_Enabled.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRuleIsNull = false;
            }
            System.Int32? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_MaxAgeInDay = null;
            if (cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_MaxAgeInDays != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_maxAgeRule_MaxAgeInDay = cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_MaxAgeInDays.Value;
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
            bool requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull = true;
            requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule = new Amazon.ElasticBeanstalk.Model.MaxCountRule();
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3 = null;
            if (cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3 = cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_DeleteSourceFromS3.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3 != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule.DeleteSourceFromS3 = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_DeleteSourceFromS3.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull = false;
            }
            System.Boolean? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled = null;
            if (cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled = cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_Enabled.Value;
            }
            if (requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule.Enabled = requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_Enabled.Value;
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRuleIsNull = false;
            }
            System.Int32? requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_MaxCount = null;
            if (cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_MaxCount != null)
            {
                requestResourceLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_resourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_maxCountRule_MaxCount = cmdletContext.ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_MaxCount.Value;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Application;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.ElasticBeanstalk.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateApplicationAsync(request);
                return task.Result;
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
            public System.String Description { get; set; }
            public System.String ResourceLifecycleConfig_ServiceRole { get; set; }
            public System.Boolean? ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_DeleteSourceFromS3 { get; set; }
            public System.Boolean? ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_Enabled { get; set; }
            public System.Int32? ResourceLifecycleConfig_VersionLifecycleConfig_MaxAgeRule_MaxAgeInDays { get; set; }
            public System.Boolean? ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_DeleteSourceFromS3 { get; set; }
            public System.Boolean? ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_Enabled { get; set; }
            public System.Int32? ResourceLifecycleConfig_VersionLifecycleConfig_MaxCountRule_MaxCount { get; set; }
        }
        
    }
}
