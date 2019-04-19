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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Deploys multiple groups in one operation. This action starts the bulk deployment of
    /// a specified set of group versions. Each group version deployment will be triggered
    /// with an adaptive rate that has a fixed upper limit. We recommend that you include
    /// an ''X-Amzn-Client-Token'' token in every ''StartBulkDeployment'' request. These requests
    /// are idempotent with respect to the token and the request parameters.
    /// </summary>
    [Cmdlet("Start", "GGBulkDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.StartBulkDeploymentResponse")]
    [AWSCmdlet("Calls the AWS Greengrass StartBulkDeployment API operation.", Operation = new[] {"StartBulkDeployment"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.StartBulkDeploymentResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.StartBulkDeploymentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartGGBulkDeploymentCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// The ARN of the execution role to associate
        /// with the bulk deployment operation. This IAM role must allow the ''greengrass:CreateDeployment''
        /// action for all group versions that are listed in the input file. This IAM role must
        /// have access to the S3 bucket containing the input file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter InputFileUri
        /// <summary>
        /// <para>
        /// The URI of the input file contained in the
        /// S3 bucket. The execution role must have ''getObject'' permissions on this bucket to
        /// access the input file. The input file is a JSON-serialized, line delimited file with
        /// UTF-8 encoding that provides a list of group and version IDs and the deployment type.
        /// This file must be less than 100 MB. Currently, AWS IoT Greengrass supports only ''NewDeployment''
        /// deployment types.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String InputFileUri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Tag(s) to add to the new resource
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InputFileUri", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GGBulkDeployment (StartBulkDeployment)"))
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
            
            context.AmznClientToken = this.AmznClientToken;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.InputFileUri = this.InputFileUri;
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.Greengrass.Model.StartBulkDeploymentRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.InputFileUri != null)
            {
                request.InputFileUri = cmdletContext.InputFileUri;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
        
        private Amazon.Greengrass.Model.StartBulkDeploymentResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.StartBulkDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "StartBulkDeployment");
            try
            {
                #if DESKTOP
                return client.StartBulkDeployment(request);
                #elif CORECLR
                return client.StartBulkDeploymentAsync(request).GetAwaiter().GetResult();
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
            public System.String AmznClientToken { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String InputFileUri { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
        }
        
    }
}
