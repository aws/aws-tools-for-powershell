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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Lists your certificates.
    /// 
    ///  
    /// <para>
    /// The results are paginated with a default page size of 25. You can retrieve additional
    /// results using the returned marker.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTCertificateList")]
    [OutputType("Amazon.IoT.Model.Certificate")]
    [AWSCmdlet("Invokes the ListCertificates operation against AWS IoT.", Operation = new[] {"ListCertificates"})]
    [AWSCmdletOutput("Amazon.IoT.Model.Certificate",
        "This cmdlet returns a collection of Certificate objects.",
        "The service call response (type ListCertificatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type String)"
    )]
    public class GetIOTCertificateListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The result page size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 PageSize { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the order for results. If True, the results are returned in ascending order,
        /// based on the creation date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AscendingOrder { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The marker for the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AscendingOrder"))
                context.AscendingOrder = this.AscendingOrder;
            context.Marker = this.Marker;
            if (ParameterWasBound("PageSize"))
                context.PageSize = this.PageSize;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListCertificatesRequest();
            
            if (cmdletContext.AscendingOrder != null)
            {
                request.AscendingOrder = cmdletContext.AscendingOrder.Value;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListCertificates(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Certificates;
                notes = new Dictionary<string, object>();
                notes["NextMarker"] = response.NextMarker;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Boolean? AscendingOrder { get; set; }
            public String Marker { get; set; }
            public Int32? PageSize { get; set; }
        }
        
    }
}
