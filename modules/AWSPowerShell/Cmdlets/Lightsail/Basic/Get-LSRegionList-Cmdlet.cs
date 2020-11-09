/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns a list of all valid regions for Amazon Lightsail. Use the <code>include availability
    /// zones</code> parameter to also return the Availability Zones in a region.
    /// </summary>
    [Cmdlet("Get", "LSRegionList")]
    [OutputType("Amazon.Lightsail.Model.Region")]
    [AWSCmdlet("Calls the Amazon Lightsail GetRegions API operation.", Operation = new[] {"GetRegions"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetRegionsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Region or Amazon.Lightsail.Model.GetRegionsResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Region objects.",
        "The service call response (type Amazon.Lightsail.Model.GetRegionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLSRegionListCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter IncludeAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether to also include Availability Zones in your get
        /// regions request. Availability Zones are indicated with a letter: e.g., <code>us-east-2a</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeAvailabilityZones")]
        public System.Boolean? IncludeAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter IncludeRelationalDatabaseAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether to also include Availability Zones for databases
        /// in your get regions request. Availability Zones are indicated with a letter (e.g.,
        /// <code>us-east-2a</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeRelationalDatabaseAvailabilityZones")]
        public System.Boolean? IncludeRelationalDatabaseAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Regions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetRegionsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetRegionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Regions";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetRegionsResponse, GetLSRegionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeAvailabilityZone = this.IncludeAvailabilityZone;
            context.IncludeRelationalDatabaseAvailabilityZone = this.IncludeRelationalDatabaseAvailabilityZone;
            
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
            
            if (cmdletContext.IncludeAvailabilityZone != null)
            {
                request.IncludeAvailabilityZones = cmdletContext.IncludeAvailabilityZone.Value;
            }
            if (cmdletContext.IncludeRelationalDatabaseAvailabilityZone != null)
            {
                request.IncludeRelationalDatabaseAvailabilityZones = cmdletContext.IncludeRelationalDatabaseAvailabilityZone.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            try
            {
                #if DESKTOP
                return client.GetRegions(request);
                #elif CORECLR
                return client.GetRegionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeAvailabilityZone { get; set; }
            public System.Boolean? IncludeRelationalDatabaseAvailabilityZone { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetRegionsResponse, GetLSRegionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Regions;
        }
        
    }
}
