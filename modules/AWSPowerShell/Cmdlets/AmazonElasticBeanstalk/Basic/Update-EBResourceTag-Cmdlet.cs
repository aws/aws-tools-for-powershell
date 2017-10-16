/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Update the list of tags applied to an AWS Elastic Beanstalk resource. Two lists can
    /// be passed: <code>TagsToAdd</code> for tags to add or update, and <code>TagsToRemove</code>.
    /// 
    ///  
    /// <para>
    /// Currently, Elastic Beanstalk only supports tagging of Elastic Beanstalk environments.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EBResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateTagsForResource operation against AWS Elastic Beanstalk.", Operation = new[] {"UpdateTagsForResource"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ResourceArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticBeanstalk.Model.UpdateTagsForResourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEBResourceTagCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resouce to be updated.</para><para>Must be the ARN of an Elastic Beanstalk environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter TagsToAdd
        /// <summary>
        /// <para>
        /// <para>A list of tags to add or update.</para><para>If a key of an existing tag is added, the tag's value is updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ElasticBeanstalk.Model.Tag[] TagsToAdd { get; set; }
        #endregion
        
        #region Parameter TagsToRemove
        /// <summary>
        /// <para>
        /// <para>A list of tag keys to remove.</para><para>If a tag key doesn't exist, it is silently ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] TagsToRemove { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ResourceArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EBResourceTag (UpdateTagsForResource)"))
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
            
            context.ResourceArn = this.ResourceArn;
            if (this.TagsToAdd != null)
            {
                context.TagsToAdd = new List<Amazon.ElasticBeanstalk.Model.Tag>(this.TagsToAdd);
            }
            if (this.TagsToRemove != null)
            {
                context.TagsToRemove = new List<System.String>(this.TagsToRemove);
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
            var request = new Amazon.ElasticBeanstalk.Model.UpdateTagsForResourceRequest();
            
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            if (cmdletContext.TagsToAdd != null)
            {
                request.TagsToAdd = cmdletContext.TagsToAdd;
            }
            if (cmdletContext.TagsToRemove != null)
            {
                request.TagsToRemove = cmdletContext.TagsToRemove;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ResourceArn;
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
        
        private Amazon.ElasticBeanstalk.Model.UpdateTagsForResourceResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.UpdateTagsForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "UpdateTagsForResource");
            try
            {
                #if DESKTOP
                return client.UpdateTagsForResource(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateTagsForResourceAsync(request);
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
            public System.String ResourceArn { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.Tag> TagsToAdd { get; set; }
            public List<System.String> TagsToRemove { get; set; }
        }
        
    }
}
