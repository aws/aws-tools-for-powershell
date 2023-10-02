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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Purchases a reserved DB instance offering.
    /// </summary>
    [Cmdlet("New", "RDSReservedDBInstancesOfferingPurchase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.ReservedDBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service PurchaseReservedDBInstancesOffering API operation.", Operation = new[] {"PurchaseReservedDBInstancesOffering"}, SelectReturnType = typeof(Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse), LegacyAlias="Get-RDSReservedDBInstancesOffering")]
    [AWSCmdletOutput("Amazon.RDS.Model.ReservedDBInstance or Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse",
        "This cmdlet returns an Amazon.RDS.Model.ReservedDBInstance object.",
        "The service call response (type Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSReservedDBInstancesOfferingPurchaseCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBInstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances to reserve.</para><para>Default: <code>1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DBInstanceCount { get; set; }
        #endregion
        
        #region Parameter ReservedDBInstanceId
        /// <summary>
        /// <para>
        /// <para>Customer-specified identifier to track this reservation.</para><para>Example: myreservationID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReservedDBInstanceId { get; set; }
        #endregion
        
        #region Parameter ReservedDBInstancesOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the Reserved DB instance offering to purchase.</para><para>Example: 438012d3-4052-4cc7-b2e3-8d3372e0e706</para>
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
        public System.String ReservedDBInstancesOfferingId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedDBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedDBInstance";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReservedDBInstancesOfferingId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReservedDBInstancesOfferingId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReservedDBInstancesOfferingId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedDBInstancesOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSReservedDBInstancesOfferingPurchase (PurchaseReservedDBInstancesOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse, NewRDSReservedDBInstancesOfferingPurchaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReservedDBInstancesOfferingId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBInstanceCount = this.DBInstanceCount;
            context.ReservedDBInstanceId = this.ReservedDBInstanceId;
            context.ReservedDBInstancesOfferingId = this.ReservedDBInstancesOfferingId;
            #if MODULAR
            if (this.ReservedDBInstancesOfferingId == null && ParameterWasBound(nameof(this.ReservedDBInstancesOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedDBInstancesOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingRequest();
            
            if (cmdletContext.DBInstanceCount != null)
            {
                request.DBInstanceCount = cmdletContext.DBInstanceCount.Value;
            }
            if (cmdletContext.ReservedDBInstanceId != null)
            {
                request.ReservedDBInstanceId = cmdletContext.ReservedDBInstanceId;
            }
            if (cmdletContext.ReservedDBInstancesOfferingId != null)
            {
                request.ReservedDBInstancesOfferingId = cmdletContext.ReservedDBInstancesOfferingId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "PurchaseReservedDBInstancesOffering");
            try
            {
                #if DESKTOP
                return client.PurchaseReservedDBInstancesOffering(request);
                #elif CORECLR
                return client.PurchaseReservedDBInstancesOfferingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DBInstanceCount { get; set; }
            public System.String ReservedDBInstanceId { get; set; }
            public System.String ReservedDBInstancesOfferingId { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse, NewRDSReservedDBInstancesOfferingPurchaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedDBInstance;
        }
        
    }
}
