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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("Edit", "R53TagsForResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ChangeTagsForResource operation against Amazon Route 53.", Operation = new[] {"ChangeTagsForResource"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ResourceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Route53.Model.ChangeTagsForResourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditR53TagsForResourceCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter AddTag
        /// <summary>
        /// <para>
        /// <para>A complex type that contains a list of <code>Tag</code> elements. Each <code>Tag</code>
        /// element identifies a tag that you want to add or update for the specified resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AddTags")]
        public Amazon.Route53.Model.Tag[] AddTag { get; set; }
        #endregion
        
        #region Parameter RemoveTagKey
        /// <summary>
        /// <para>
        /// <para>A list of <code>Tag</code> keys that you want to remove from the specified resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoveTagKeys")]
        public System.String[] RemoveTagKey { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource for which you want to add, change, or delete tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the resource.</para><para>- The resource type for health checks is <code>healthcheck</code>.</para><para>- The resource type for hosted zones is <code>hostedzone</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.TagResourceType")]
        public Amazon.Route53.TagResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ResourceId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-R53TagsForResource (ChangeTagsForResource)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ResourceType = this.ResourceType;
            context.ResourceId = this.ResourceId;
            if (this.AddTag != null)
            {
                context.AddTags = new List<Amazon.Route53.Model.Tag>(this.AddTag);
            }
            if (this.RemoveTagKey != null)
            {
                context.RemoveTagKeys = new List<System.String>(this.RemoveTagKey);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.ChangeTagsForResourceRequest();
            
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.AddTags != null)
            {
                request.AddTags = cmdletContext.AddTags;
            }
            if (cmdletContext.RemoveTagKeys != null)
            {
                request.RemoveTagKeys = cmdletContext.RemoveTagKeys;
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
                    pipelineOutput = this.ResourceId;
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
        
        private static Amazon.Route53.Model.ChangeTagsForResourceResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ChangeTagsForResourceRequest request)
        {
            return client.ChangeTagsForResource(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.Route53.TagResourceType ResourceType { get; set; }
            public System.String ResourceId { get; set; }
            public List<Amazon.Route53.Model.Tag> AddTags { get; set; }
            public List<System.String> RemoveTagKeys { get; set; }
        }
        
    }
}
