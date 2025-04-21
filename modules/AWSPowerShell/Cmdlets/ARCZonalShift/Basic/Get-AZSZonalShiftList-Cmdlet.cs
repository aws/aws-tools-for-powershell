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
using Amazon.ARCZonalShift;
using Amazon.ARCZonalShift.Model;

namespace Amazon.PowerShell.Cmdlets.AZS
{
    /// <summary>
    /// Lists all active and completed zonal shifts in Amazon Route 53 Application Recovery
    /// Controller in your Amazon Web Services account in this Amazon Web Services Region.
    /// </summary>
    [Cmdlet("Get", "AZSZonalShiftList")]
    [OutputType("Amazon.ARCZonalShift.Model.ZonalShiftSummary")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift ListZonalShifts API operation.", Operation = new[] {"ListZonalShifts"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.ListZonalShiftsResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.ZonalShiftSummary or Amazon.ARCZonalShift.Model.ListZonalShiftsResponse",
        "This cmdlet returns a collection of Amazon.ARCZonalShift.Model.ZonalShiftSummary objects.",
        "The service call response (type Amazon.ARCZonalShift.Model.ListZonalShiftsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAZSZonalShiftListCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the resource that you want to list zonal shifts for. The identifier
        /// is the Amazon Resource Name (ARN) for the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>A status for a zonal shift.</para><para>The <c>Status</c> for a zonal shift can have one of the following values:</para><ul><li><para><b>ACTIVE</b>: The zonal shift has been started and active.</para></li><li><para><b>EXPIRED</b>: The zonal shift has expired (the expiry time was exceeded).</para></li><li><para><b>CANCELED</b>: The zonal shift was canceled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.ARCZonalShift.ZonalShiftStatus")]
        public Amazon.ARCZonalShift.ZonalShiftStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of objects that you want to return with this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to receive the next page of results. Valid only if you received
        /// a <c>nextToken</c> response in the previous request. If you did, it indicates that
        /// more output is available. Set this parameter to the value provided by the previous
        /// call's <c>nextToken</c> response to request the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.ListZonalShiftsResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.ListZonalShiftsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Status parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Status' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Status' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.ListZonalShiftsResponse, GetAZSZonalShiftListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Status;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceIdentifier = this.ResourceIdentifier;
            context.Status = this.Status;
            
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
            var request = new Amazon.ARCZonalShift.Model.ListZonalShiftsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.ARCZonalShift.Model.ListZonalShiftsResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.ListZonalShiftsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "ListZonalShifts");
            try
            {
                #if DESKTOP
                return client.ListZonalShifts(request);
                #elif CORECLR
                return client.ListZonalShiftsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public Amazon.ARCZonalShift.ZonalShiftStatus Status { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.ListZonalShiftsResponse, GetAZSZonalShiftListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
