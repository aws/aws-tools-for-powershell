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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Creates a new cost anomaly detection monitor with the requested type and monitor specification.
    /// </summary>
    [Cmdlet("New", "CEAnomalyMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cost Explorer CreateAnomalyMonitor API operation.", Operation = new[] {"CreateAnomalyMonitor"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse))]
    [AWSCmdletOutput("System.String or Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCEAnomalyMonitorCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter AnomalyMonitor_CreationDate
        /// <summary>
        /// <para>
        /// <para>The date when the monitor was created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyMonitor_CreationDate { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_DimensionalValueCount
        /// <summary>
        /// <para>
        /// <para>The value for evaluated dimensions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AnomalyMonitor_DimensionalValueCount { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_LastEvaluatedDate
        /// <summary>
        /// <para>
        /// <para>The date when the monitor last evaluated for anomalies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyMonitor_LastEvaluatedDate { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_LastUpdatedDate
        /// <summary>
        /// <para>
        /// <para>The date when the monitor was last updated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyMonitor_LastUpdatedDate { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_MonitorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyMonitor_MonitorArn { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_MonitorDimension
        /// <summary>
        /// <para>
        /// <para>The dimensions to evaluate. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.MonitorDimension")]
        public Amazon.CostExplorer.MonitorDimension AnomalyMonitor_MonitorDimension { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor. </para>
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
        public System.String AnomalyMonitor_MonitorName { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_MonitorSpecification
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression AnomalyMonitor_MonitorSpecification { get; set; }
        #endregion
        
        #region Parameter AnomalyMonitor_MonitorType
        /// <summary>
        /// <para>
        /// <para>The possible type values. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.MonitorType")]
        public Amazon.CostExplorer.MonitorType AnomalyMonitor_MonitorType { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>An optional list of tags to associate with the specified <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_AnomalyMonitor.html"><code>AnomalyMonitor</code></a>. You can use resource tags to control access to your
        /// <code>monitor</code> using IAM policies.</para><para>Each tag consists of a key and a value, and each key must be unique for the resource.
        /// The following restrictions apply to resource tags:</para><ul><li><para>Although the maximum number of array members is 200, you can assign a maximum of 50
        /// user-tags to one resource. The remaining are reserved for Amazon Web Services use</para></li><li><para>The maximum length of a key is 128 characters</para></li><li><para>The maximum length of a value is 256 characters</para></li><li><para>Keys and values can only contain alphanumeric characters, spaces, and any of the following:
        /// <code>_.:/=+@-</code></para></li><li><para>Keys and values are case sensitive</para></li><li><para>Keys and values are trimmed for any leading or trailing whitespaces</para></li><li><para>Don’t use <code>aws:</code> as a prefix for your keys. This prefix is reserved for
        /// Amazon Web Services use</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.CostExplorer.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MonitorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MonitorArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnomalyMonitor_MonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CEAnomalyMonitor (CreateAnomalyMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse, NewCEAnomalyMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyMonitor_CreationDate = this.AnomalyMonitor_CreationDate;
            context.AnomalyMonitor_DimensionalValueCount = this.AnomalyMonitor_DimensionalValueCount;
            context.AnomalyMonitor_LastEvaluatedDate = this.AnomalyMonitor_LastEvaluatedDate;
            context.AnomalyMonitor_LastUpdatedDate = this.AnomalyMonitor_LastUpdatedDate;
            context.AnomalyMonitor_MonitorArn = this.AnomalyMonitor_MonitorArn;
            context.AnomalyMonitor_MonitorDimension = this.AnomalyMonitor_MonitorDimension;
            context.AnomalyMonitor_MonitorName = this.AnomalyMonitor_MonitorName;
            #if MODULAR
            if (this.AnomalyMonitor_MonitorName == null && ParameterWasBound(nameof(this.AnomalyMonitor_MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyMonitor_MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyMonitor_MonitorSpecification = this.AnomalyMonitor_MonitorSpecification;
            context.AnomalyMonitor_MonitorType = this.AnomalyMonitor_MonitorType;
            #if MODULAR
            if (this.AnomalyMonitor_MonitorType == null && ParameterWasBound(nameof(this.AnomalyMonitor_MonitorType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyMonitor_MonitorType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.CostExplorer.Model.ResourceTag>(this.ResourceTag);
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
            var request = new Amazon.CostExplorer.Model.CreateAnomalyMonitorRequest();
            
            
             // populate AnomalyMonitor
            var requestAnomalyMonitorIsNull = true;
            request.AnomalyMonitor = new Amazon.CostExplorer.Model.AnomalyMonitor();
            System.String requestAnomalyMonitor_anomalyMonitor_CreationDate = null;
            if (cmdletContext.AnomalyMonitor_CreationDate != null)
            {
                requestAnomalyMonitor_anomalyMonitor_CreationDate = cmdletContext.AnomalyMonitor_CreationDate;
            }
            if (requestAnomalyMonitor_anomalyMonitor_CreationDate != null)
            {
                request.AnomalyMonitor.CreationDate = requestAnomalyMonitor_anomalyMonitor_CreationDate;
                requestAnomalyMonitorIsNull = false;
            }
            System.Int32? requestAnomalyMonitor_anomalyMonitor_DimensionalValueCount = null;
            if (cmdletContext.AnomalyMonitor_DimensionalValueCount != null)
            {
                requestAnomalyMonitor_anomalyMonitor_DimensionalValueCount = cmdletContext.AnomalyMonitor_DimensionalValueCount.Value;
            }
            if (requestAnomalyMonitor_anomalyMonitor_DimensionalValueCount != null)
            {
                request.AnomalyMonitor.DimensionalValueCount = requestAnomalyMonitor_anomalyMonitor_DimensionalValueCount.Value;
                requestAnomalyMonitorIsNull = false;
            }
            System.String requestAnomalyMonitor_anomalyMonitor_LastEvaluatedDate = null;
            if (cmdletContext.AnomalyMonitor_LastEvaluatedDate != null)
            {
                requestAnomalyMonitor_anomalyMonitor_LastEvaluatedDate = cmdletContext.AnomalyMonitor_LastEvaluatedDate;
            }
            if (requestAnomalyMonitor_anomalyMonitor_LastEvaluatedDate != null)
            {
                request.AnomalyMonitor.LastEvaluatedDate = requestAnomalyMonitor_anomalyMonitor_LastEvaluatedDate;
                requestAnomalyMonitorIsNull = false;
            }
            System.String requestAnomalyMonitor_anomalyMonitor_LastUpdatedDate = null;
            if (cmdletContext.AnomalyMonitor_LastUpdatedDate != null)
            {
                requestAnomalyMonitor_anomalyMonitor_LastUpdatedDate = cmdletContext.AnomalyMonitor_LastUpdatedDate;
            }
            if (requestAnomalyMonitor_anomalyMonitor_LastUpdatedDate != null)
            {
                request.AnomalyMonitor.LastUpdatedDate = requestAnomalyMonitor_anomalyMonitor_LastUpdatedDate;
                requestAnomalyMonitorIsNull = false;
            }
            System.String requestAnomalyMonitor_anomalyMonitor_MonitorArn = null;
            if (cmdletContext.AnomalyMonitor_MonitorArn != null)
            {
                requestAnomalyMonitor_anomalyMonitor_MonitorArn = cmdletContext.AnomalyMonitor_MonitorArn;
            }
            if (requestAnomalyMonitor_anomalyMonitor_MonitorArn != null)
            {
                request.AnomalyMonitor.MonitorArn = requestAnomalyMonitor_anomalyMonitor_MonitorArn;
                requestAnomalyMonitorIsNull = false;
            }
            Amazon.CostExplorer.MonitorDimension requestAnomalyMonitor_anomalyMonitor_MonitorDimension = null;
            if (cmdletContext.AnomalyMonitor_MonitorDimension != null)
            {
                requestAnomalyMonitor_anomalyMonitor_MonitorDimension = cmdletContext.AnomalyMonitor_MonitorDimension;
            }
            if (requestAnomalyMonitor_anomalyMonitor_MonitorDimension != null)
            {
                request.AnomalyMonitor.MonitorDimension = requestAnomalyMonitor_anomalyMonitor_MonitorDimension;
                requestAnomalyMonitorIsNull = false;
            }
            System.String requestAnomalyMonitor_anomalyMonitor_MonitorName = null;
            if (cmdletContext.AnomalyMonitor_MonitorName != null)
            {
                requestAnomalyMonitor_anomalyMonitor_MonitorName = cmdletContext.AnomalyMonitor_MonitorName;
            }
            if (requestAnomalyMonitor_anomalyMonitor_MonitorName != null)
            {
                request.AnomalyMonitor.MonitorName = requestAnomalyMonitor_anomalyMonitor_MonitorName;
                requestAnomalyMonitorIsNull = false;
            }
            Amazon.CostExplorer.Model.Expression requestAnomalyMonitor_anomalyMonitor_MonitorSpecification = null;
            if (cmdletContext.AnomalyMonitor_MonitorSpecification != null)
            {
                requestAnomalyMonitor_anomalyMonitor_MonitorSpecification = cmdletContext.AnomalyMonitor_MonitorSpecification;
            }
            if (requestAnomalyMonitor_anomalyMonitor_MonitorSpecification != null)
            {
                request.AnomalyMonitor.MonitorSpecification = requestAnomalyMonitor_anomalyMonitor_MonitorSpecification;
                requestAnomalyMonitorIsNull = false;
            }
            Amazon.CostExplorer.MonitorType requestAnomalyMonitor_anomalyMonitor_MonitorType = null;
            if (cmdletContext.AnomalyMonitor_MonitorType != null)
            {
                requestAnomalyMonitor_anomalyMonitor_MonitorType = cmdletContext.AnomalyMonitor_MonitorType;
            }
            if (requestAnomalyMonitor_anomalyMonitor_MonitorType != null)
            {
                request.AnomalyMonitor.MonitorType = requestAnomalyMonitor_anomalyMonitor_MonitorType;
                requestAnomalyMonitorIsNull = false;
            }
             // determine if request.AnomalyMonitor should be set to null
            if (requestAnomalyMonitorIsNull)
            {
                request.AnomalyMonitor = null;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
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
        
        private Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.CreateAnomalyMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "CreateAnomalyMonitor");
            try
            {
                #if DESKTOP
                return client.CreateAnomalyMonitor(request);
                #elif CORECLR
                return client.CreateAnomalyMonitorAsync(request).GetAwaiter().GetResult();
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
            public System.String AnomalyMonitor_CreationDate { get; set; }
            public System.Int32? AnomalyMonitor_DimensionalValueCount { get; set; }
            public System.String AnomalyMonitor_LastEvaluatedDate { get; set; }
            public System.String AnomalyMonitor_LastUpdatedDate { get; set; }
            public System.String AnomalyMonitor_MonitorArn { get; set; }
            public Amazon.CostExplorer.MonitorDimension AnomalyMonitor_MonitorDimension { get; set; }
            public System.String AnomalyMonitor_MonitorName { get; set; }
            public Amazon.CostExplorer.Model.Expression AnomalyMonitor_MonitorSpecification { get; set; }
            public Amazon.CostExplorer.MonitorType AnomalyMonitor_MonitorType { get; set; }
            public List<Amazon.CostExplorer.Model.ResourceTag> ResourceTag { get; set; }
            public System.Func<Amazon.CostExplorer.Model.CreateAnomalyMonitorResponse, NewCEAnomalyMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MonitorArn;
        }
        
    }
}
