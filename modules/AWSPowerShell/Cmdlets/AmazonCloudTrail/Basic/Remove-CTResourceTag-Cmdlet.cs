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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Removes the specified tags from a trail.
    /// </summary>
    [Cmdlet("Remove", "CTResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CloudTrail RemoveTags API operation.", Operation = new[] {"RemoveTags"}, LegacyAlias="Remove-CTTag")]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.CloudTrail.Model.RemoveTagsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCTResourceTagCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the trail from which tags should be removed. The format of a
        /// trail ARN is:</para><para><code>arn:aws:cloudtrail:us-east-2:123456789012:trail/MyTrail</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter TagsList
        /// <summary>
        /// <para>
        /// <para>Specifies a list of tags to be removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CloudTrail.Model.Tag[] TagsList { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CTResourceTag (RemoveTags)"))
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
            
            context.ResourceId = this.ResourceId;
            if (this.TagsList != null)
            {
                context.TagsList = new List<Amazon.CloudTrail.Model.Tag>(this.TagsList);
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
            var request = new Amazon.CloudTrail.Model.RemoveTagsRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.TagsList != null)
            {
                request.TagsList = cmdletContext.TagsList;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.CloudTrail.Model.RemoveTagsResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.RemoveTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "RemoveTags");
            try
            {
                #if DESKTOP
                return client.RemoveTags(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RemoveTagsAsync(request);
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
            public System.String ResourceId { get; set; }
            public List<Amazon.CloudTrail.Model.Tag> TagsList { get; set; }
        }
        
    }
}
