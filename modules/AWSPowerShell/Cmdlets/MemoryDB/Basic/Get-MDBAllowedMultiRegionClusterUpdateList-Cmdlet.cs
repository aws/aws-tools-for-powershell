/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Lists the allowed updates for a multi-Region cluster.
    /// </summary>
    [Cmdlet("Get", "MDBAllowedMultiRegionClusterUpdateList")]
    [OutputType("Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse")]
    [AWSCmdlet("Calls the Amazon MemoryDB ListAllowedMultiRegionClusterUpdates API operation.", Operation = new[] {"ListAllowedMultiRegionClusterUpdates"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse object containing multiple properties."
    )]
    public partial class GetMDBAllowedMultiRegionClusterUpdateListCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MultiRegionClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MultiRegionClusterName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MultiRegionClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MultiRegionClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MultiRegionClusterName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse, GetMDBAllowedMultiRegionClusterUpdateListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MultiRegionClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MultiRegionClusterName = this.MultiRegionClusterName;
            #if MODULAR
            if (this.MultiRegionClusterName == null && ParameterWasBound(nameof(this.MultiRegionClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiRegionClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesRequest();
            
            if (cmdletContext.MultiRegionClusterName != null)
            {
                request.MultiRegionClusterName = cmdletContext.MultiRegionClusterName;
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
        
        private Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "ListAllowedMultiRegionClusterUpdates");
            try
            {
                #if DESKTOP
                return client.ListAllowedMultiRegionClusterUpdates(request);
                #elif CORECLR
                return client.ListAllowedMultiRegionClusterUpdatesAsync(request).GetAwaiter().GetResult();
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
            public System.String MultiRegionClusterName { get; set; }
            public System.Func<Amazon.MemoryDB.Model.ListAllowedMultiRegionClusterUpdatesResponse, GetMDBAllowedMultiRegionClusterUpdateListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
