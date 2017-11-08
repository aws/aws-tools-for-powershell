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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Amazon.XRay.IAmazonXRay.PutTraceSegments
    /// </summary>
    [Cmdlet("Write", "XRTraceSegment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.XRay.Model.UnprocessedTraceSegment")]
    [AWSCmdlet("Calls the AWS X-Ray PutTraceSegments API operation.", Operation = new[] {"PutTraceSegments"})]
    [AWSCmdletOutput("Amazon.XRay.Model.UnprocessedTraceSegment",
        "This cmdlet returns a collection of UnprocessedTraceSegment objects.",
        "The service call response (type Amazon.XRay.Model.PutTraceSegmentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteXRTraceSegmentCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        #region Parameter TraceSegmentDocument
        /// <summary>
        /// <para>
        /// <para>A string containing a JSON document defining one or more segments or subsegments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("TraceSegmentDocuments")]
        public System.String[] TraceSegmentDocument { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TraceSegmentDocument", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-XRTraceSegment (PutTraceSegments)"))
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
            
            if (this.TraceSegmentDocument != null)
            {
                context.TraceSegmentDocuments = new List<System.String>(this.TraceSegmentDocument);
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
            var request = new Amazon.XRay.Model.PutTraceSegmentsRequest();
            
            if (cmdletContext.TraceSegmentDocuments != null)
            {
                request.TraceSegmentDocuments = cmdletContext.TraceSegmentDocuments;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.UnprocessedTraceSegments;
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
        
        private Amazon.XRay.Model.PutTraceSegmentsResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.PutTraceSegmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "PutTraceSegments");
            try
            {
                #if DESKTOP
                return client.PutTraceSegments(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutTraceSegmentsAsync(request);
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
            public List<System.String> TraceSegmentDocuments { get; set; }
        }
        
    }
}
