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
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Takes an <code>AddressId</code> and returns specific details about that address in
    /// the form of an <code>Address</code> object.
    /// </summary>
    [Cmdlet("Get", "SNOWAddress")]
    [OutputType("Amazon.Snowball.Model.Address")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball DescribeAddress API operation.", Operation = new[] {"DescribeAddress"})]
    [AWSCmdletOutput("Amazon.Snowball.Model.Address",
        "This cmdlet returns a Address object.",
        "The service call response (type Amazon.Snowball.Model.DescribeAddressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSNOWAddressCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        #region Parameter AddressId
        /// <summary>
        /// <para>
        /// <para>The automatically generated ID for a specific address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AddressId { get; set; }
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
            
            context.AddressId = this.AddressId;
            
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
            var request = new Amazon.Snowball.Model.DescribeAddressRequest();
            
            if (cmdletContext.AddressId != null)
            {
                request.AddressId = cmdletContext.AddressId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Address;
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
        
        private Amazon.Snowball.Model.DescribeAddressResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.DescribeAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "DescribeAddress");
            try
            {
                #if DESKTOP
                return client.DescribeAddress(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeAddressAsync(request);
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
            public System.String AddressId { get; set; }
        }
        
    }
}
