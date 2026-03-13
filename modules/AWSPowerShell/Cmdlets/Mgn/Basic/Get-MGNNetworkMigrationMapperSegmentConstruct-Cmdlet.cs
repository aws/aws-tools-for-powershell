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
using System.Threading;
using Amazon.Mgn;
using Amazon.Mgn.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Retrieves detailed information about a specific construct within a mapper segment,
    /// including its properties and configuration data.
    /// </summary>
    [Cmdlet("Get", "MGNNetworkMigrationMapperSegmentConstruct")]
    [OutputType("Amazon.Mgn.Model.NetworkMigrationMapperSegmentConstruct")]
    [AWSCmdlet("Calls the Application Migration Service GetNetworkMigrationMapperSegmentConstruct API operation.", Operation = new[] {"GetNetworkMigrationMapperSegmentConstruct"}, SelectReturnType = typeof(Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.NetworkMigrationMapperSegmentConstruct or Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse",
        "This cmdlet returns an Amazon.Mgn.Model.NetworkMigrationMapperSegmentConstruct object.",
        "The service call response (type Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMGNNetworkMigrationMapperSegmentConstructCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConstructID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the construct within the segment.</para>
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
        public System.String ConstructID { get; set; }
        #endregion
        
        #region Parameter NetworkMigrationDefinitionID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network migration definition.</para>
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
        public System.String NetworkMigrationDefinitionID { get; set; }
        #endregion
        
        #region Parameter NetworkMigrationExecutionID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network migration execution.</para>
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
        public System.String NetworkMigrationExecutionID { get; set; }
        #endregion
        
        #region Parameter SegmentID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the mapper segment.</para>
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
        public System.String SegmentID { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Construct'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Construct";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse, GetMGNNetworkMigrationMapperSegmentConstructCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConstructID = this.ConstructID;
            #if MODULAR
            if (this.ConstructID == null && ParameterWasBound(nameof(this.ConstructID)))
            {
                WriteWarning("You are passing $null as a value for parameter ConstructID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkMigrationDefinitionID = this.NetworkMigrationDefinitionID;
            #if MODULAR
            if (this.NetworkMigrationDefinitionID == null && ParameterWasBound(nameof(this.NetworkMigrationDefinitionID)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkMigrationDefinitionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkMigrationExecutionID = this.NetworkMigrationExecutionID;
            #if MODULAR
            if (this.NetworkMigrationExecutionID == null && ParameterWasBound(nameof(this.NetworkMigrationExecutionID)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkMigrationExecutionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SegmentID = this.SegmentID;
            #if MODULAR
            if (this.SegmentID == null && ParameterWasBound(nameof(this.SegmentID)))
            {
                WriteWarning("You are passing $null as a value for parameter SegmentID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructRequest();
            
            if (cmdletContext.ConstructID != null)
            {
                request.ConstructID = cmdletContext.ConstructID;
            }
            if (cmdletContext.NetworkMigrationDefinitionID != null)
            {
                request.NetworkMigrationDefinitionID = cmdletContext.NetworkMigrationDefinitionID;
            }
            if (cmdletContext.NetworkMigrationExecutionID != null)
            {
                request.NetworkMigrationExecutionID = cmdletContext.NetworkMigrationExecutionID;
            }
            if (cmdletContext.SegmentID != null)
            {
                request.SegmentID = cmdletContext.SegmentID;
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
        
        private Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "GetNetworkMigrationMapperSegmentConstruct");
            try
            {
                return client.GetNetworkMigrationMapperSegmentConstructAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConstructID { get; set; }
            public System.String NetworkMigrationDefinitionID { get; set; }
            public System.String NetworkMigrationExecutionID { get; set; }
            public System.String SegmentID { get; set; }
            public System.Func<Amazon.Mgn.Model.GetNetworkMigrationMapperSegmentConstructResponse, GetMGNNetworkMigrationMapperSegmentConstructCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Construct;
        }
        
    }
}
