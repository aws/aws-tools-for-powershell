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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Adds one or more tags to an object, up to a limit of 10. Each tag consists of a key
    /// and an optional value. If you add a tag using a key that is already associated with
    /// the ML object, <code>AddTags</code> updates the tag's value.
    /// </summary>
    [Cmdlet("Add", "MLResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MachineLearning.Model.AddTagsResponse")]
    [AWSCmdlet("Invokes the AddTags operation against Amazon Machine Learning.", Operation = new[] {"AddTags"}, LegacyAlias="Add-MLTag")]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.AddTagsResponse",
        "This cmdlet returns a Amazon.MachineLearning.Model.AddTagsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddMLResourceTagCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the ML object to tag. For example, <code>exampleModelId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the ML object to tag. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MachineLearning.TaggableResourceType")]
        public Amazon.MachineLearning.TaggableResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to use to create tags. If you specify a key without specifying
        /// a value, Amazon ML creates a tag with the specified key and a value of null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.MachineLearning.Model.Tag[] Tag { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-MLResourceTag (AddTags)"))
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
            context.ResourceType = this.ResourceType;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.MachineLearning.Model.Tag>(this.Tag);
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
            var request = new Amazon.MachineLearning.Model.AddTagsRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.MachineLearning.Model.AddTagsResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.AddTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "AddTags");
            #if DESKTOP
            return client.AddTags(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddTagsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ResourceId { get; set; }
            public Amazon.MachineLearning.TaggableResourceType ResourceType { get; set; }
            public List<Amazon.MachineLearning.Model.Tag> Tags { get; set; }
        }
        
    }
}
