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
using Amazon.ComprehendMedical;
using Amazon.ComprehendMedical.Model;

namespace Amazon.PowerShell.Cmdlets.CMPM
{
    /// <summary>
    /// Inspects the clinical text for personal health information (PHI) entities and entity
    /// category, location, and confidence score on that information.
    /// </summary>
    [Cmdlet("Find", "CMPMPersonalHealthInformation")]
    [OutputType("Amazon.ComprehendMedical.Model.Entity")]
    [AWSCmdlet("Calls the AWS Comprehend Medical DetectPHI API operation.", Operation = new[] {"DetectPHI"})]
    [AWSCmdletOutput("Amazon.ComprehendMedical.Model.Entity",
        "This cmdlet returns a collection of Entity objects.",
        "The service call response (type Amazon.ComprehendMedical.Model.DetectPHIResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: PaginationToken (type System.String)"
    )]
    public partial class FindCMPMPersonalHealthInformationCmdlet : AmazonComprehendMedicalClientCmdlet, IExecutor
    {
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para> A UTF-8 text string containing the clinical content being examined for PHI entities.
        /// Each string must contain fewer than 20,000 bytes of characters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Text { get; set; }
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
            
            context.Text = this.Text;
            
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
            var request = new Amazon.ComprehendMedical.Model.DetectPHIRequest();
            
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Entities;
                notes = new Dictionary<string, object>();
                notes["PaginationToken"] = response.PaginationToken;
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
        
        private Amazon.ComprehendMedical.Model.DetectPHIResponse CallAWSServiceOperation(IAmazonComprehendMedical client, Amazon.ComprehendMedical.Model.DetectPHIRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Comprehend Medical", "DetectPHI");
            try
            {
                #if DESKTOP
                return client.DetectPHI(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DetectPHIAsync(request);
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
            public System.String Text { get; set; }
        }
        
    }
}
