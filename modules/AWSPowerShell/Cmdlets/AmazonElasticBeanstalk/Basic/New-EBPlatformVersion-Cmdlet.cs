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
    /// Create a new version of your custom platform.
    /// </summary>
    [Cmdlet("New", "EBPlatformVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.CreatePlatformVersionResponse")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk CreatePlatformVersion API operation.", Operation = new[] {"CreatePlatformVersion"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.CreatePlatformVersionResponse",
        "This cmdlet returns a Amazon.ElasticBeanstalk.Model.CreatePlatformVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEBPlatformVersionCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the builder environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter OptionSetting
        /// <summary>
        /// <para>
        /// <para>The configuration option settings to apply to the builder environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OptionSettings")]
        public Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting[] OptionSetting { get; set; }
        #endregion
        
        #region Parameter PlatformName
        /// <summary>
        /// <para>
        /// <para>The name of your custom platform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PlatformName { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The number, such as 1.0.2, for the new platform version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter PlatformDefinitionBundle_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlatformDefinitionBundle_S3Bucket { get; set; }
        #endregion
        
        #region Parameter PlatformDefinitionBundle_S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlatformDefinitionBundle_S3Key { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PlatformName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBPlatformVersion (CreatePlatformVersion)"))
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
            
            context.EnvironmentName = this.EnvironmentName;
            if (this.OptionSetting != null)
            {
                context.OptionSettings = new List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting>(this.OptionSetting);
            }
            context.PlatformDefinitionBundle_S3Bucket = this.PlatformDefinitionBundle_S3Bucket;
            context.PlatformDefinitionBundle_S3Key = this.PlatformDefinitionBundle_S3Key;
            context.PlatformName = this.PlatformName;
            context.PlatformVersion = this.PlatformVersion;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.CreatePlatformVersionRequest();
            
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.OptionSettings != null)
            {
                request.OptionSettings = cmdletContext.OptionSettings;
            }
            
             // populate PlatformDefinitionBundle
            bool requestPlatformDefinitionBundleIsNull = true;
            request.PlatformDefinitionBundle = new Amazon.ElasticBeanstalk.Model.S3Location();
            System.String requestPlatformDefinitionBundle_platformDefinitionBundle_S3Bucket = null;
            if (cmdletContext.PlatformDefinitionBundle_S3Bucket != null)
            {
                requestPlatformDefinitionBundle_platformDefinitionBundle_S3Bucket = cmdletContext.PlatformDefinitionBundle_S3Bucket;
            }
            if (requestPlatformDefinitionBundle_platformDefinitionBundle_S3Bucket != null)
            {
                request.PlatformDefinitionBundle.S3Bucket = requestPlatformDefinitionBundle_platformDefinitionBundle_S3Bucket;
                requestPlatformDefinitionBundleIsNull = false;
            }
            System.String requestPlatformDefinitionBundle_platformDefinitionBundle_S3Key = null;
            if (cmdletContext.PlatformDefinitionBundle_S3Key != null)
            {
                requestPlatformDefinitionBundle_platformDefinitionBundle_S3Key = cmdletContext.PlatformDefinitionBundle_S3Key;
            }
            if (requestPlatformDefinitionBundle_platformDefinitionBundle_S3Key != null)
            {
                request.PlatformDefinitionBundle.S3Key = requestPlatformDefinitionBundle_platformDefinitionBundle_S3Key;
                requestPlatformDefinitionBundleIsNull = false;
            }
             // determine if request.PlatformDefinitionBundle should be set to null
            if (requestPlatformDefinitionBundleIsNull)
            {
                request.PlatformDefinitionBundle = null;
            }
            if (cmdletContext.PlatformName != null)
            {
                request.PlatformName = cmdletContext.PlatformName;
            }
            if (cmdletContext.PlatformVersion != null)
            {
                request.PlatformVersion = cmdletContext.PlatformVersion;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.ElasticBeanstalk.Model.CreatePlatformVersionResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.CreatePlatformVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "CreatePlatformVersion");
            try
            {
                #if DESKTOP
                return client.CreatePlatformVersion(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreatePlatformVersionAsync(request);
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
            public System.String EnvironmentName { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting> OptionSettings { get; set; }
            public System.String PlatformDefinitionBundle_S3Bucket { get; set; }
            public System.String PlatformDefinitionBundle_S3Key { get; set; }
            public System.String PlatformName { get; set; }
            public System.String PlatformVersion { get; set; }
        }
        
    }
}
