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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Switches over the specified secondary Amazon DocumentDB cluster to be the new primary
    /// Amazon DocumentDB cluster in the global database cluster.
    /// </summary>
    [Cmdlet("Request", "DOCSwitchoverGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) SwitchoverGlobalCluster API operation.", Operation = new[] {"SwitchoverGlobalCluster"}, SelectReturnType = typeof(Amazon.DocDB.Model.SwitchoverGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.GlobalCluster or Amazon.DocDB.Model.SwitchoverGlobalClusterResponse",
        "This cmdlet returns an Amazon.DocDB.Model.GlobalCluster object.",
        "The service call response (type Amazon.DocDB.Model.SwitchoverGlobalClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestDOCSwitchoverGlobalClusterCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DocumentDB global database cluster to switch over. The
        /// identifier is the unique key assigned by the user when the cluster is created. In
        /// other words, it's the name of the global cluster. This parameter isn’t case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing global cluster (Amazon DocumentDB global
        /// database).</para></li><li><para>Minimum length of 1. Maximum length of 255.</para></li></ul><para>Pattern: <c>[A-Za-z][0-9A-Za-z-:._]*</c></para>
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
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetDbClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the secondary Amazon DocumentDB cluster to promote to the new primary
        /// for the global database cluster. Use the Amazon Resource Name (ARN) for the identifier
        /// so that Amazon DocumentDB can locate the cluster in its Amazon Web Services region.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing secondary cluster.</para></li><li><para>Minimum length of 1. Maximum length of 255.</para></li></ul><para>Pattern: <c>[A-Za-z][0-9A-Za-z-:._]*</c></para>
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
        public System.String TargetDbClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.SwitchoverGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.SwitchoverGlobalClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalClusterIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-DOCSwitchoverGlobalCluster (SwitchoverGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.SwitchoverGlobalClusterResponse, RequestDOCSwitchoverGlobalClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            #if MODULAR
            if (this.GlobalClusterIdentifier == null && ParameterWasBound(nameof(this.GlobalClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetDbClusterIdentifier = this.TargetDbClusterIdentifier;
            #if MODULAR
            if (this.TargetDbClusterIdentifier == null && ParameterWasBound(nameof(this.TargetDbClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDbClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.SwitchoverGlobalClusterRequest();
            
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
            }
            if (cmdletContext.TargetDbClusterIdentifier != null)
            {
                request.TargetDbClusterIdentifier = cmdletContext.TargetDbClusterIdentifier;
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
        
        private Amazon.DocDB.Model.SwitchoverGlobalClusterResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.SwitchoverGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "SwitchoverGlobalCluster");
            try
            {
                #if DESKTOP
                return client.SwitchoverGlobalCluster(request);
                #elif CORECLR
                return client.SwitchoverGlobalClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String GlobalClusterIdentifier { get; set; }
            public System.String TargetDbClusterIdentifier { get; set; }
            public System.Func<Amazon.DocDB.Model.SwitchoverGlobalClusterResponse, RequestDOCSwitchoverGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}
