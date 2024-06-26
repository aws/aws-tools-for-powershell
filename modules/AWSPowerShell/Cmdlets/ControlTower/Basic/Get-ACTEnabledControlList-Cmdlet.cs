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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// Lists the controls enabled by Amazon Web Services Control Tower on the specified organizational
    /// unit and the accounts it contains. For usage examples, see the <a href="https://docs.aws.amazon.com/controltower/latest/controlreference/control-api-examples-short.html"><i>Controls Reference Guide</i></a>.
    /// </summary>
    [Cmdlet("Get", "ACTEnabledControlList")]
    [OutputType("Amazon.ControlTower.Model.EnabledControlSummary")]
    [AWSCmdlet("Calls the AWS Control Tower ListEnabledControls API operation.", Operation = new[] {"ListEnabledControls"}, SelectReturnType = typeof(Amazon.ControlTower.Model.ListEnabledControlsResponse))]
    [AWSCmdletOutput("Amazon.ControlTower.Model.EnabledControlSummary or Amazon.ControlTower.Model.ListEnabledControlsResponse",
        "This cmdlet returns a collection of Amazon.ControlTower.Model.EnabledControlSummary objects.",
        "The service call response (type Amazon.ControlTower.Model.ListEnabledControlsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetACTEnabledControlListCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_ControlIdentifier
        /// <summary>
        /// <para>
        /// <para>The set of <c>controlIdentifier</c> returned by the filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ControlIdentifiers")]
        public System.String[] Filter_ControlIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter_DriftStatus
        /// <summary>
        /// <para>
        /// <para>A list of <c>DriftStatus</c> items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DriftStatuses")]
        public System.String[] Filter_DriftStatus { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>A list of <c>EnablementStatus</c> items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Statuses")]
        public System.String[] Filter_Status { get; set; }
        #endregion
        
        #region Parameter TargetIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the organizational unit. For information on how to find the <c>targetIdentifier</c>,
        /// see <a href="https://docs.aws.amazon.com/controltower/latest/APIReference/Welcome.html">the
        /// overview page</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TargetIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>How many results to return per API call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to continue the list from a previous API call with the same parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnabledControls'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.ListEnabledControlsResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.ListEnabledControlsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnabledControls";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.ListEnabledControlsResponse, GetACTEnabledControlListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter_ControlIdentifier != null)
            {
                context.Filter_ControlIdentifier = new List<System.String>(this.Filter_ControlIdentifier);
            }
            if (this.Filter_DriftStatus != null)
            {
                context.Filter_DriftStatus = new List<System.String>(this.Filter_DriftStatus);
            }
            if (this.Filter_Status != null)
            {
                context.Filter_Status = new List<System.String>(this.Filter_Status);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TargetIdentifier = this.TargetIdentifier;
            
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
            var request = new Amazon.ControlTower.Model.ListEnabledControlsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ControlTower.Model.EnabledControlFilter();
            List<System.String> requestFilter_filter_ControlIdentifier = null;
            if (cmdletContext.Filter_ControlIdentifier != null)
            {
                requestFilter_filter_ControlIdentifier = cmdletContext.Filter_ControlIdentifier;
            }
            if (requestFilter_filter_ControlIdentifier != null)
            {
                request.Filter.ControlIdentifiers = requestFilter_filter_ControlIdentifier;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_DriftStatus = null;
            if (cmdletContext.Filter_DriftStatus != null)
            {
                requestFilter_filter_DriftStatus = cmdletContext.Filter_DriftStatus;
            }
            if (requestFilter_filter_DriftStatus != null)
            {
                request.Filter.DriftStatuses = requestFilter_filter_DriftStatus;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Statuses = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TargetIdentifier != null)
            {
                request.TargetIdentifier = cmdletContext.TargetIdentifier;
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
        
        private Amazon.ControlTower.Model.ListEnabledControlsResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.ListEnabledControlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "ListEnabledControls");
            try
            {
                #if DESKTOP
                return client.ListEnabledControls(request);
                #elif CORECLR
                return client.ListEnabledControlsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filter_ControlIdentifier { get; set; }
            public List<System.String> Filter_DriftStatus { get; set; }
            public List<System.String> Filter_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String TargetIdentifier { get; set; }
            public System.Func<Amazon.ControlTower.Model.ListEnabledControlsResponse, GetACTEnabledControlListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnabledControls;
        }
        
    }
}
