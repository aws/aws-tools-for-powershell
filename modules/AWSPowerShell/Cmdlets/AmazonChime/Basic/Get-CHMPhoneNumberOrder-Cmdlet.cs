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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Retrieves details for the specified phone number order, such as order creation timestamp,
    /// phone numbers in E.164 format, product type, and order status.
    /// </summary>
    [Cmdlet("Get", "CHMPhoneNumberOrder")]
    [OutputType("Amazon.Chime.Model.PhoneNumberOrder")]
    [AWSCmdlet("Calls the Amazon Chime GetPhoneNumberOrder API operation.", Operation = new[] {"GetPhoneNumberOrder"})]
    [AWSCmdletOutput("Amazon.Chime.Model.PhoneNumberOrder",
        "This cmdlet returns a PhoneNumberOrder object.",
        "The service call response (type Amazon.Chime.Model.GetPhoneNumberOrderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCHMPhoneNumberOrderCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter PhoneNumberOrderId
        /// <summary>
        /// <para>
        /// <para>The ID for the phone number order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PhoneNumberOrderId { get; set; }
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
            
            context.PhoneNumberOrderId = this.PhoneNumberOrderId;
            
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
            var request = new Amazon.Chime.Model.GetPhoneNumberOrderRequest();
            
            if (cmdletContext.PhoneNumberOrderId != null)
            {
                request.PhoneNumberOrderId = cmdletContext.PhoneNumberOrderId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PhoneNumberOrder;
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
        
        private Amazon.Chime.Model.GetPhoneNumberOrderResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.GetPhoneNumberOrderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "GetPhoneNumberOrder");
            try
            {
                #if DESKTOP
                return client.GetPhoneNumberOrder(request);
                #elif CORECLR
                return client.GetPhoneNumberOrderAsync(request).GetAwaiter().GetResult();
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
            public System.String PhoneNumberOrderId { get; set; }
        }
        
    }
}
