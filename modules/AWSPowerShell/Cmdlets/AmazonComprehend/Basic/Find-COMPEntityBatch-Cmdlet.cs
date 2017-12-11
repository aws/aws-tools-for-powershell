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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Inspects the text of a batch of documents and returns information about them. For
    /// more information about entities, see <a>how-entities</a>
    /// </summary>
    [Cmdlet("Find", "COMPEntityBatch")]
    [OutputType("Amazon.Comprehend.Model.BatchDetectEntitiesResponse")]
    [AWSCmdlet("Calls the Amazon Comprehend BatchDetectEntities API operation.", Operation = new[] {"BatchDetectEntities"})]
    [AWSCmdletOutput("Amazon.Comprehend.Model.BatchDetectEntitiesResponse",
        "This cmdlet returns a Amazon.Comprehend.Model.BatchDetectEntitiesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindCOMPEntityBatchCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language of the input documents. All documents must be in the same language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LanguageCode { get; set; }
        #endregion
        
        #region Parameter TextList
        /// <summary>
        /// <para>
        /// <para>A list containing the text of the input documents. The list can contain a maximum
        /// of 25 documents. Each document must contain fewer than 5,000 bytes of UTF-8 encoded
        /// characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] TextList { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.LanguageCode = this.LanguageCode;
            if (this.TextList != null)
            {
                context.TextList = new List<System.String>(this.TextList);
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
            var request = new Amazon.Comprehend.Model.BatchDetectEntitiesRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.TextList != null)
            {
                request.TextList = cmdletContext.TextList;
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
        
        private Amazon.Comprehend.Model.BatchDetectEntitiesResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.BatchDetectEntitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "BatchDetectEntities");
            try
            {
                #if DESKTOP
                return client.BatchDetectEntities(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchDetectEntitiesAsync(request);
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
            public System.String LanguageCode { get; set; }
            public List<System.String> TextList { get; set; }
        }
        
    }
}
