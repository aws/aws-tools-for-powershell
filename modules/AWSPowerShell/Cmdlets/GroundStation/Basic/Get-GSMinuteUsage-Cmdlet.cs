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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Returns the number of reserved minutes used by account.
    /// </summary>
    [Cmdlet("Get", "GSMinuteUsage")]
    [OutputType("Amazon.GroundStation.Model.GetMinuteUsageResponse")]
    [AWSCmdlet("Calls the AWS Ground Station GetMinuteUsage API operation.", Operation = new[] {"GetMinuteUsage"}, SelectReturnType = typeof(Amazon.GroundStation.Model.GetMinuteUsageResponse))]
    [AWSCmdletOutput("Amazon.GroundStation.Model.GetMinuteUsageResponse",
        "This cmdlet returns an Amazon.GroundStation.Model.GetMinuteUsageResponse object containing multiple properties."
    )]
    public partial class GetGSMinuteUsageCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Month
        /// <summary>
        /// <para>
        /// <para>The month being requested, with a value of 1-12.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Month { get; set; }
        #endregion
        
        #region Parameter Year
        /// <summary>
        /// <para>
        /// <para>The year being requested, in the format of YYYY.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Year { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.GetMinuteUsageResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.GetMinuteUsageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.GetMinuteUsageResponse, GetGSMinuteUsageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Month = this.Month;
            #if MODULAR
            if (this.Month == null && ParameterWasBound(nameof(this.Month)))
            {
                WriteWarning("You are passing $null as a value for parameter Month which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Year = this.Year;
            #if MODULAR
            if (this.Year == null && ParameterWasBound(nameof(this.Year)))
            {
                WriteWarning("You are passing $null as a value for parameter Year which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.GroundStation.Model.GetMinuteUsageRequest();
            
            if (cmdletContext.Month != null)
            {
                request.Month = cmdletContext.Month.Value;
            }
            if (cmdletContext.Year != null)
            {
                request.Year = cmdletContext.Year.Value;
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
        
        private Amazon.GroundStation.Model.GetMinuteUsageResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.GetMinuteUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "GetMinuteUsage");
            try
            {
                #if DESKTOP
                return client.GetMinuteUsage(request);
                #elif CORECLR
                return client.GetMinuteUsageAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Month { get; set; }
            public System.Int32? Year { get; set; }
            public System.Func<Amazon.GroundStation.Model.GetMinuteUsageResponse, GetGSMinuteUsageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
