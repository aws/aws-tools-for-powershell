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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Remove tags from a CloudFront resource.
    /// </summary>
    [Cmdlet("Remove", "CFResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UntagResource operation against Amazon CloudFront.", Operation = new[] {"UntagResource"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Resource parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudFront.Model.UntagResourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveCFResourceTagCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter TagKey
        /// <summary>
        /// <para>
        /// A complex type that contains Tag key elements
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] TagKey { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// An ARN of a CloudFront resource.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Resource parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Resource", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFResourceTag (UntagResource)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Resource = this.Resource;
            if (this.TagKey != null)
            {
                context.TagKey = new List<System.String>(this.TagKey);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudFront.Model.UntagResourceRequest();
            
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            
             // populate TagKeys
            bool requestTagKeysIsNull = true;
            request.TagKeys = new Amazon.CloudFront.Model.TagKeys();
            List<System.String> requestTagKeys_tagKey = null;
            if (cmdletContext.TagKey != null)
            {
                requestTagKeys_tagKey = cmdletContext.TagKey;
            }
            if (requestTagKeys_tagKey != null)
            {
                request.TagKeys.Items = requestTagKeys_tagKey;
                requestTagKeysIsNull = false;
            }
             // determine if request.TagKeys should be set to null
            if (requestTagKeysIsNull)
            {
                request.TagKeys = null;
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
                    pipelineOutput = this.Resource;
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
        
        private static Amazon.CloudFront.Model.UntagResourceResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UntagResourceRequest request)
        {
            return client.UntagResource(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Resource { get; set; }
            public List<System.String> TagKey { get; set; }
        }
        
    }
}
