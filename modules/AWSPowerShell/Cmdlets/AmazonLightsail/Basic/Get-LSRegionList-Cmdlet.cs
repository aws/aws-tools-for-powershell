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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns a list of all valid regions for Amazon Lightsail.
    /// </summary>
    [Cmdlet("Get", "LSRegionList")]
    [OutputType("Amazon.Lightsail.Model.Region")]
    [AWSCmdlet("Invokes the GetRegions operation against Amazon Lightsail.", Operation = new[] {"GetRegions"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Region",
        "This cmdlet returns a collection of Region objects.",
        "The service call response (type Amazon.Lightsail.Model.GetRegionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLSRegionListCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter IncludeAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether to also include Availability Zones in your get
        /// regions request. Availability Zones are indicated with a letter: e.g., <code>us-east-1a</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeAvailabilityZones")]
        public System.Boolean IncludeAvailabilityZone { get; set; }
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
            
            if (ParameterWasBound("IncludeAvailabilityZone"))
                context.IncludeAvailabilityZones = this.IncludeAvailabilityZone;
            
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
            var request = new Amazon.Lightsail.Model.GetRegionsRequest();
            
            if (cmdletContext.IncludeAvailabilityZones != null)
            {
                request.IncludeAvailabilityZones = cmdletContext.IncludeAvailabilityZones.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Regions;
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
        
        private Amazon.Lightsail.Model.GetRegionsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetRegionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetRegions");
            #if DESKTOP
            return client.GetRegions(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetRegionsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? IncludeAvailabilityZones { get; set; }
        }
        
    }
}
