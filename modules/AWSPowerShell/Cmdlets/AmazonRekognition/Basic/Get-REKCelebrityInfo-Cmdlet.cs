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
    /// Gets the name and additional information about a celebrity based on his or her Rekognition
    /// ID. The additional information is returned as an array of URLs. If there is no additional
    /// information about the celebrity, this list is empty. For more information, see <a>get-celebrity-info-procedure</a>.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions to perform the <code>rekognition:GetCelebrityInfo</code>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "REKCelebrityInfo")]
    [OutputType("Amazon.Rekognition.Model.GetCelebrityInfoResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetCelebrityInfo API operation.", Operation = new[] {"GetCelebrityInfo"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetCelebrityInfoResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.GetCelebrityInfoResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetREKCelebrityInfoCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID for the celebrity. You get the celebrity ID from a call to the operation, which
        /// recognizes celebrities in an image. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Id { get; set; }
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
            
            context.Id = this.Id;
            
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
            var request = new Amazon.Rekognition.Model.GetCelebrityInfoRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.Rekognition.Model.GetCelebrityInfoResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetCelebrityInfoRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetCelebrityInfo");
            try
            {
                #if DESKTOP
                return client.GetCelebrityInfo(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetCelebrityInfoAsync(request);
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
            public System.String Id { get; set; }
        }
        
    }
}
