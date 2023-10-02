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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a path to analyze for reachability.
    /// 
    ///  
    /// <para>
    /// Reachability Analyzer enables you to analyze and debug network reachability between
    /// two resources in your virtual private cloud (VPC). For more information, see the <a href="https://docs.aws.amazon.com/vpc/latest/reachability/">Reachability Analyzer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2NetworkInsightsPath", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.NetworkInsightsPath")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateNetworkInsightsPath API operation.", Operation = new[] {"CreateNetworkInsightsPath"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateNetworkInsightsPathResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInsightsPath or Amazon.EC2.Model.CreateNetworkInsightsPathResponse",
        "This cmdlet returns an Amazon.EC2.Model.NetworkInsightsPath object.",
        "The service call response (type Amazon.EC2.Model.CreateNetworkInsightsPathResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2NetworkInsightsPathCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the destination. If the resource is in another account, you must
        /// specify an ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter FilterAtDestination_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The destination IPv4 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterAtDestination_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter FilterAtSource_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The destination IPv4 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterAtSource_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter DestinationIp
        /// <summary>
        /// <para>
        /// <para>The IP address of the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationIp { get; set; }
        #endregion
        
        #region Parameter DestinationPort
        /// <summary>
        /// <para>
        /// <para>The destination port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DestinationPort { get; set; }
        #endregion
        
        #region Parameter FilterAtDestination_DestinationPortRange_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtDestination_DestinationPortRange_FromPort { get; set; }
        #endregion
        
        #region Parameter FilterAtDestination_SourcePortRange_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtDestination_SourcePortRange_FromPort { get; set; }
        #endregion
        
        #region Parameter FilterAtSource_DestinationPortRange_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtSource_DestinationPortRange_FromPort { get; set; }
        #endregion
        
        #region Parameter FilterAtSource_SourcePortRange_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtSource_SourcePortRange_FromPort { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.Protocol")]
        public Amazon.EC2.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the source. If the resource is in another account, you must specify
        /// an ARN.</para>
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
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter FilterAtDestination_SourceAddress
        /// <summary>
        /// <para>
        /// <para>The source IPv4 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterAtDestination_SourceAddress { get; set; }
        #endregion
        
        #region Parameter FilterAtSource_SourceAddress
        /// <summary>
        /// <para>
        /// <para>The source IPv4 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterAtSource_SourceAddress { get; set; }
        #endregion
        
        #region Parameter SourceIp
        /// <summary>
        /// <para>
        /// <para>The IP address of the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIp { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to add to the path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter FilterAtDestination_DestinationPortRange_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtDestination_DestinationPortRange_ToPort { get; set; }
        #endregion
        
        #region Parameter FilterAtDestination_SourcePortRange_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtDestination_SourcePortRange_ToPort { get; set; }
        #endregion
        
        #region Parameter FilterAtSource_DestinationPortRange_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtSource_DestinationPortRange_ToPort { get; set; }
        #endregion
        
        #region Parameter FilterAtSource_SourcePortRange_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FilterAtSource_SourcePortRange_ToPort { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkInsightsPath'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateNetworkInsightsPathResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateNetworkInsightsPathResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkInsightsPath";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NetworkInsightsPath (CreateNetworkInsightsPath)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateNetworkInsightsPathResponse, NewEC2NetworkInsightsPathCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Destination = this.Destination;
            context.DestinationIp = this.DestinationIp;
            context.DestinationPort = this.DestinationPort;
            context.FilterAtDestination_DestinationAddress = this.FilterAtDestination_DestinationAddress;
            context.FilterAtDestination_DestinationPortRange_FromPort = this.FilterAtDestination_DestinationPortRange_FromPort;
            context.FilterAtDestination_DestinationPortRange_ToPort = this.FilterAtDestination_DestinationPortRange_ToPort;
            context.FilterAtDestination_SourceAddress = this.FilterAtDestination_SourceAddress;
            context.FilterAtDestination_SourcePortRange_FromPort = this.FilterAtDestination_SourcePortRange_FromPort;
            context.FilterAtDestination_SourcePortRange_ToPort = this.FilterAtDestination_SourcePortRange_ToPort;
            context.FilterAtSource_DestinationAddress = this.FilterAtSource_DestinationAddress;
            context.FilterAtSource_DestinationPortRange_FromPort = this.FilterAtSource_DestinationPortRange_FromPort;
            context.FilterAtSource_DestinationPortRange_ToPort = this.FilterAtSource_DestinationPortRange_ToPort;
            context.FilterAtSource_SourceAddress = this.FilterAtSource_SourceAddress;
            context.FilterAtSource_SourcePortRange_FromPort = this.FilterAtSource_SourcePortRange_FromPort;
            context.FilterAtSource_SourcePortRange_ToPort = this.FilterAtSource_SourcePortRange_ToPort;
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceIp = this.SourceIp;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateNetworkInsightsPathRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.DestinationIp != null)
            {
                request.DestinationIp = cmdletContext.DestinationIp;
            }
            if (cmdletContext.DestinationPort != null)
            {
                request.DestinationPort = cmdletContext.DestinationPort.Value;
            }
            
             // populate FilterAtDestination
            var requestFilterAtDestinationIsNull = true;
            request.FilterAtDestination = new Amazon.EC2.Model.PathRequestFilter();
            System.String requestFilterAtDestination_filterAtDestination_DestinationAddress = null;
            if (cmdletContext.FilterAtDestination_DestinationAddress != null)
            {
                requestFilterAtDestination_filterAtDestination_DestinationAddress = cmdletContext.FilterAtDestination_DestinationAddress;
            }
            if (requestFilterAtDestination_filterAtDestination_DestinationAddress != null)
            {
                request.FilterAtDestination.DestinationAddress = requestFilterAtDestination_filterAtDestination_DestinationAddress;
                requestFilterAtDestinationIsNull = false;
            }
            System.String requestFilterAtDestination_filterAtDestination_SourceAddress = null;
            if (cmdletContext.FilterAtDestination_SourceAddress != null)
            {
                requestFilterAtDestination_filterAtDestination_SourceAddress = cmdletContext.FilterAtDestination_SourceAddress;
            }
            if (requestFilterAtDestination_filterAtDestination_SourceAddress != null)
            {
                request.FilterAtDestination.SourceAddress = requestFilterAtDestination_filterAtDestination_SourceAddress;
                requestFilterAtDestinationIsNull = false;
            }
            Amazon.EC2.Model.RequestFilterPortRange requestFilterAtDestination_filterAtDestination_DestinationPortRange = null;
            
             // populate DestinationPortRange
            var requestFilterAtDestination_filterAtDestination_DestinationPortRangeIsNull = true;
            requestFilterAtDestination_filterAtDestination_DestinationPortRange = new Amazon.EC2.Model.RequestFilterPortRange();
            System.Int32? requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_FromPort = null;
            if (cmdletContext.FilterAtDestination_DestinationPortRange_FromPort != null)
            {
                requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_FromPort = cmdletContext.FilterAtDestination_DestinationPortRange_FromPort.Value;
            }
            if (requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_FromPort != null)
            {
                requestFilterAtDestination_filterAtDestination_DestinationPortRange.FromPort = requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_FromPort.Value;
                requestFilterAtDestination_filterAtDestination_DestinationPortRangeIsNull = false;
            }
            System.Int32? requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_ToPort = null;
            if (cmdletContext.FilterAtDestination_DestinationPortRange_ToPort != null)
            {
                requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_ToPort = cmdletContext.FilterAtDestination_DestinationPortRange_ToPort.Value;
            }
            if (requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_ToPort != null)
            {
                requestFilterAtDestination_filterAtDestination_DestinationPortRange.ToPort = requestFilterAtDestination_filterAtDestination_DestinationPortRange_filterAtDestination_DestinationPortRange_ToPort.Value;
                requestFilterAtDestination_filterAtDestination_DestinationPortRangeIsNull = false;
            }
             // determine if requestFilterAtDestination_filterAtDestination_DestinationPortRange should be set to null
            if (requestFilterAtDestination_filterAtDestination_DestinationPortRangeIsNull)
            {
                requestFilterAtDestination_filterAtDestination_DestinationPortRange = null;
            }
            if (requestFilterAtDestination_filterAtDestination_DestinationPortRange != null)
            {
                request.FilterAtDestination.DestinationPortRange = requestFilterAtDestination_filterAtDestination_DestinationPortRange;
                requestFilterAtDestinationIsNull = false;
            }
            Amazon.EC2.Model.RequestFilterPortRange requestFilterAtDestination_filterAtDestination_SourcePortRange = null;
            
             // populate SourcePortRange
            var requestFilterAtDestination_filterAtDestination_SourcePortRangeIsNull = true;
            requestFilterAtDestination_filterAtDestination_SourcePortRange = new Amazon.EC2.Model.RequestFilterPortRange();
            System.Int32? requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_FromPort = null;
            if (cmdletContext.FilterAtDestination_SourcePortRange_FromPort != null)
            {
                requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_FromPort = cmdletContext.FilterAtDestination_SourcePortRange_FromPort.Value;
            }
            if (requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_FromPort != null)
            {
                requestFilterAtDestination_filterAtDestination_SourcePortRange.FromPort = requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_FromPort.Value;
                requestFilterAtDestination_filterAtDestination_SourcePortRangeIsNull = false;
            }
            System.Int32? requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_ToPort = null;
            if (cmdletContext.FilterAtDestination_SourcePortRange_ToPort != null)
            {
                requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_ToPort = cmdletContext.FilterAtDestination_SourcePortRange_ToPort.Value;
            }
            if (requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_ToPort != null)
            {
                requestFilterAtDestination_filterAtDestination_SourcePortRange.ToPort = requestFilterAtDestination_filterAtDestination_SourcePortRange_filterAtDestination_SourcePortRange_ToPort.Value;
                requestFilterAtDestination_filterAtDestination_SourcePortRangeIsNull = false;
            }
             // determine if requestFilterAtDestination_filterAtDestination_SourcePortRange should be set to null
            if (requestFilterAtDestination_filterAtDestination_SourcePortRangeIsNull)
            {
                requestFilterAtDestination_filterAtDestination_SourcePortRange = null;
            }
            if (requestFilterAtDestination_filterAtDestination_SourcePortRange != null)
            {
                request.FilterAtDestination.SourcePortRange = requestFilterAtDestination_filterAtDestination_SourcePortRange;
                requestFilterAtDestinationIsNull = false;
            }
             // determine if request.FilterAtDestination should be set to null
            if (requestFilterAtDestinationIsNull)
            {
                request.FilterAtDestination = null;
            }
            
             // populate FilterAtSource
            var requestFilterAtSourceIsNull = true;
            request.FilterAtSource = new Amazon.EC2.Model.PathRequestFilter();
            System.String requestFilterAtSource_filterAtSource_DestinationAddress = null;
            if (cmdletContext.FilterAtSource_DestinationAddress != null)
            {
                requestFilterAtSource_filterAtSource_DestinationAddress = cmdletContext.FilterAtSource_DestinationAddress;
            }
            if (requestFilterAtSource_filterAtSource_DestinationAddress != null)
            {
                request.FilterAtSource.DestinationAddress = requestFilterAtSource_filterAtSource_DestinationAddress;
                requestFilterAtSourceIsNull = false;
            }
            System.String requestFilterAtSource_filterAtSource_SourceAddress = null;
            if (cmdletContext.FilterAtSource_SourceAddress != null)
            {
                requestFilterAtSource_filterAtSource_SourceAddress = cmdletContext.FilterAtSource_SourceAddress;
            }
            if (requestFilterAtSource_filterAtSource_SourceAddress != null)
            {
                request.FilterAtSource.SourceAddress = requestFilterAtSource_filterAtSource_SourceAddress;
                requestFilterAtSourceIsNull = false;
            }
            Amazon.EC2.Model.RequestFilterPortRange requestFilterAtSource_filterAtSource_DestinationPortRange = null;
            
             // populate DestinationPortRange
            var requestFilterAtSource_filterAtSource_DestinationPortRangeIsNull = true;
            requestFilterAtSource_filterAtSource_DestinationPortRange = new Amazon.EC2.Model.RequestFilterPortRange();
            System.Int32? requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_FromPort = null;
            if (cmdletContext.FilterAtSource_DestinationPortRange_FromPort != null)
            {
                requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_FromPort = cmdletContext.FilterAtSource_DestinationPortRange_FromPort.Value;
            }
            if (requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_FromPort != null)
            {
                requestFilterAtSource_filterAtSource_DestinationPortRange.FromPort = requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_FromPort.Value;
                requestFilterAtSource_filterAtSource_DestinationPortRangeIsNull = false;
            }
            System.Int32? requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_ToPort = null;
            if (cmdletContext.FilterAtSource_DestinationPortRange_ToPort != null)
            {
                requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_ToPort = cmdletContext.FilterAtSource_DestinationPortRange_ToPort.Value;
            }
            if (requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_ToPort != null)
            {
                requestFilterAtSource_filterAtSource_DestinationPortRange.ToPort = requestFilterAtSource_filterAtSource_DestinationPortRange_filterAtSource_DestinationPortRange_ToPort.Value;
                requestFilterAtSource_filterAtSource_DestinationPortRangeIsNull = false;
            }
             // determine if requestFilterAtSource_filterAtSource_DestinationPortRange should be set to null
            if (requestFilterAtSource_filterAtSource_DestinationPortRangeIsNull)
            {
                requestFilterAtSource_filterAtSource_DestinationPortRange = null;
            }
            if (requestFilterAtSource_filterAtSource_DestinationPortRange != null)
            {
                request.FilterAtSource.DestinationPortRange = requestFilterAtSource_filterAtSource_DestinationPortRange;
                requestFilterAtSourceIsNull = false;
            }
            Amazon.EC2.Model.RequestFilterPortRange requestFilterAtSource_filterAtSource_SourcePortRange = null;
            
             // populate SourcePortRange
            var requestFilterAtSource_filterAtSource_SourcePortRangeIsNull = true;
            requestFilterAtSource_filterAtSource_SourcePortRange = new Amazon.EC2.Model.RequestFilterPortRange();
            System.Int32? requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_FromPort = null;
            if (cmdletContext.FilterAtSource_SourcePortRange_FromPort != null)
            {
                requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_FromPort = cmdletContext.FilterAtSource_SourcePortRange_FromPort.Value;
            }
            if (requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_FromPort != null)
            {
                requestFilterAtSource_filterAtSource_SourcePortRange.FromPort = requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_FromPort.Value;
                requestFilterAtSource_filterAtSource_SourcePortRangeIsNull = false;
            }
            System.Int32? requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_ToPort = null;
            if (cmdletContext.FilterAtSource_SourcePortRange_ToPort != null)
            {
                requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_ToPort = cmdletContext.FilterAtSource_SourcePortRange_ToPort.Value;
            }
            if (requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_ToPort != null)
            {
                requestFilterAtSource_filterAtSource_SourcePortRange.ToPort = requestFilterAtSource_filterAtSource_SourcePortRange_filterAtSource_SourcePortRange_ToPort.Value;
                requestFilterAtSource_filterAtSource_SourcePortRangeIsNull = false;
            }
             // determine if requestFilterAtSource_filterAtSource_SourcePortRange should be set to null
            if (requestFilterAtSource_filterAtSource_SourcePortRangeIsNull)
            {
                requestFilterAtSource_filterAtSource_SourcePortRange = null;
            }
            if (requestFilterAtSource_filterAtSource_SourcePortRange != null)
            {
                request.FilterAtSource.SourcePortRange = requestFilterAtSource_filterAtSource_SourcePortRange;
                requestFilterAtSourceIsNull = false;
            }
             // determine if request.FilterAtSource should be set to null
            if (requestFilterAtSourceIsNull)
            {
                request.FilterAtSource = null;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.SourceIp != null)
            {
                request.SourceIp = cmdletContext.SourceIp;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateNetworkInsightsPathResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNetworkInsightsPathRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateNetworkInsightsPath");
            try
            {
                #if DESKTOP
                return client.CreateNetworkInsightsPath(request);
                #elif CORECLR
                return client.CreateNetworkInsightsPathAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Destination { get; set; }
            public System.String DestinationIp { get; set; }
            public System.Int32? DestinationPort { get; set; }
            public System.String FilterAtDestination_DestinationAddress { get; set; }
            public System.Int32? FilterAtDestination_DestinationPortRange_FromPort { get; set; }
            public System.Int32? FilterAtDestination_DestinationPortRange_ToPort { get; set; }
            public System.String FilterAtDestination_SourceAddress { get; set; }
            public System.Int32? FilterAtDestination_SourcePortRange_FromPort { get; set; }
            public System.Int32? FilterAtDestination_SourcePortRange_ToPort { get; set; }
            public System.String FilterAtSource_DestinationAddress { get; set; }
            public System.Int32? FilterAtSource_DestinationPortRange_FromPort { get; set; }
            public System.Int32? FilterAtSource_DestinationPortRange_ToPort { get; set; }
            public System.String FilterAtSource_SourceAddress { get; set; }
            public System.Int32? FilterAtSource_SourcePortRange_FromPort { get; set; }
            public System.Int32? FilterAtSource_SourcePortRange_ToPort { get; set; }
            public Amazon.EC2.Protocol Protocol { get; set; }
            public System.String Source { get; set; }
            public System.String SourceIp { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateNetworkInsightsPathResponse, NewEC2NetworkInsightsPathCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkInsightsPath;
        }
        
    }
}
