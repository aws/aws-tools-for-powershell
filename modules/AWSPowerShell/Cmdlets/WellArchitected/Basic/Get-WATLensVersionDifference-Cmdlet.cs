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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Get lens version differences.
    /// </summary>
    [Cmdlet("Get", "WATLensVersionDifference")]
    [OutputType("Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool GetLensVersionDifference API operation.", Operation = new[] {"GetLensVersionDifference"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse object containing multiple properties."
    )]
    public partial class GetWATLensVersionDifferenceCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BaseLensVersion
        /// <summary>
        /// <para>
        /// <para>The base version of the lens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BaseLensVersion { get; set; }
        #endregion
        
        #region Parameter LensAlias
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LensAlias { get; set; }
        #endregion
        
        #region Parameter TargetLensVersion
        /// <summary>
        /// <para>
        /// <para>The lens version to target a difference for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetLensVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse, GetWATLensVersionDifferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseLensVersion = this.BaseLensVersion;
            context.LensAlias = this.LensAlias;
            #if MODULAR
            if (this.LensAlias == null && ParameterWasBound(nameof(this.LensAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter LensAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetLensVersion = this.TargetLensVersion;
            
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
            var request = new Amazon.WellArchitected.Model.GetLensVersionDifferenceRequest();
            
            if (cmdletContext.BaseLensVersion != null)
            {
                request.BaseLensVersion = cmdletContext.BaseLensVersion;
            }
            if (cmdletContext.LensAlias != null)
            {
                request.LensAlias = cmdletContext.LensAlias;
            }
            if (cmdletContext.TargetLensVersion != null)
            {
                request.TargetLensVersion = cmdletContext.TargetLensVersion;
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
        
        private Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.GetLensVersionDifferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "GetLensVersionDifference");
            try
            {
                #if DESKTOP
                return client.GetLensVersionDifference(request);
                #elif CORECLR
                return client.GetLensVersionDifferenceAsync(request).GetAwaiter().GetResult();
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
            public System.String BaseLensVersion { get; set; }
            public System.String LensAlias { get; set; }
            public System.String TargetLensVersion { get; set; }
            public System.Func<Amazon.WellArchitected.Model.GetLensVersionDifferenceResponse, GetWATLensVersionDifferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
