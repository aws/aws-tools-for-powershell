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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Returns information about a recovery point.
    /// </summary>
    [Cmdlet("Get", "RSSRecoveryPoint")]
    [OutputType("Amazon.RedshiftServerless.Model.RecoveryPoint")]
    [AWSCmdlet("Calls the Redshift Serverless GetRecoveryPoint API operation.", Operation = new[] {"GetRecoveryPoint"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.GetRecoveryPointResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.RecoveryPoint or Amazon.RedshiftServerless.Model.GetRecoveryPointResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.RecoveryPoint object.",
        "The service call response (type Amazon.RedshiftServerless.Model.GetRecoveryPointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRSSRecoveryPointCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RecoveryPointId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the recovery point to return information for.</para>
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
        public System.String RecoveryPointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecoveryPoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.GetRecoveryPointResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.GetRecoveryPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecoveryPoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecoveryPointId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecoveryPointId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecoveryPointId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.GetRecoveryPointResponse, GetRSSRecoveryPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecoveryPointId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RecoveryPointId = this.RecoveryPointId;
            #if MODULAR
            if (this.RecoveryPointId == null && ParameterWasBound(nameof(this.RecoveryPointId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RedshiftServerless.Model.GetRecoveryPointRequest();
            
            if (cmdletContext.RecoveryPointId != null)
            {
                request.RecoveryPointId = cmdletContext.RecoveryPointId;
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
        
        private Amazon.RedshiftServerless.Model.GetRecoveryPointResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.GetRecoveryPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "GetRecoveryPoint");
            try
            {
                #if DESKTOP
                return client.GetRecoveryPoint(request);
                #elif CORECLR
                return client.GetRecoveryPointAsync(request).GetAwaiter().GetResult();
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
            public System.String RecoveryPointId { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.GetRecoveryPointResponse, GetRSSRecoveryPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecoveryPoint;
        }
        
    }
}
