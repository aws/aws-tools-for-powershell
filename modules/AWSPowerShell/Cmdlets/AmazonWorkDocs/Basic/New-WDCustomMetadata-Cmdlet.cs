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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Adds one or more custom properties to the specified resource (a folder, document,
    /// or version).
    /// </summary>
    [Cmdlet("New", "WDCustomMetadata", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateCustomMetadata operation against Amazon WorkDocs.", Operation = new[] {"CreateCustomMetadata"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ResourceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.WorkDocs.Model.CreateCustomMetadataResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWDCustomMetadataCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. This field should not be set when using administrative
        /// API actions, as in accessing the API using AWS credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter CustomMetadata
        /// <summary>
        /// <para>
        /// <para>Custom metadata in the form of name-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable CustomMetadata { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the version, if the custom metadata is being added to a document version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VersionId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WDCustomMetadata (CreateCustomMetadata)"))
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
            
            context.AuthenticationToken = this.AuthenticationToken;
            if (this.CustomMetadata != null)
            {
                context.CustomMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomMetadata.Keys)
                {
                    context.CustomMetadata.Add((String)hashKey, (String)(this.CustomMetadata[hashKey]));
                }
            }
            context.ResourceId = this.ResourceId;
            context.VersionId = this.VersionId;
            
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
            var request = new Amazon.WorkDocs.Model.CreateCustomMetadataRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.CustomMetadata != null)
            {
                request.CustomMetadata = cmdletContext.CustomMetadata;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
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
        
        private Amazon.WorkDocs.Model.CreateCustomMetadataResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.CreateCustomMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "CreateCustomMetadata");
            #if DESKTOP
            return client.CreateCustomMetadata(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateCustomMetadataAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AuthenticationToken { get; set; }
            public Dictionary<System.String, System.String> CustomMetadata { get; set; }
            public System.String ResourceId { get; set; }
            public System.String VersionId { get; set; }
        }
        
    }
}
