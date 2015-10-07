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
    /// Lists your policies.
    /// </summary>
    [Cmdlet("Get", "IOTPolicyList")]
    [OutputType("Amazon.IoT.Model.Policy")]
    [AWSCmdlet("Invokes the ListPolicies operation against AWS IoT.", Operation = new[] {"ListPolicies"})]
    [AWSCmdletOutput("Amazon.IoT.Model.Policy",
        "This cmdlet returns a collection of Policy objects.",
        "The service call response (type ListPoliciesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type String)"
    )]
    public class GetIOTPolicyListCmdlet : AmazonIoTClientCmdlet, IExecutor
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
        /// <para>Specifies the order for results. If true, the results are returned in ascending creation
        /// order.</para>
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
            var request = new ListPoliciesRequest();
            
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
                var response = client.ListPolicies(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Policies;
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
