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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Deletes the specified collection. Note that this operation removes all faces in the
    /// collection. For an example, see <a>delete-collection-procedure</a>.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions to perform the <code>rekognition:DeleteCollection</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "REKCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.Int32")]
    [AWSCmdlet("Calls the Amazon Rekognition DeleteCollection API operation.", Operation = new[] {"DeleteCollection"})]
    [AWSCmdletOutput("System.Int32",
        "This cmdlet returns a Int32 object.",
        "The service call response (type Amazon.Rekognition.Model.DeleteCollectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveREKCollectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>ID of the collection to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CollectionId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CollectionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-REKCollection (DeleteCollection)"))
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
            
            context.CollectionId = this.CollectionId;
            
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
            var request = new Amazon.Rekognition.Model.DeleteCollectionRequest();
            
            if (cmdletContext.CollectionId != null)
            {
                request.CollectionId = cmdletContext.CollectionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StatusCode;
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
        
        private Amazon.Rekognition.Model.DeleteCollectionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DeleteCollectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "DeleteCollection");
            try
            {
                #if DESKTOP
                return client.DeleteCollection(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteCollectionAsync(request);
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
            public System.String CollectionId { get; set; }
        }
        
    }
}
