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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates one or more resource record set protections in a hosted zone. A protection
    /// applies to every resource record set in the hosted zone that has the specified name
    /// and type. While a protection exists, Route 53 rejects any <c>ChangeResourceRecordSets</c>
    /// request that creates, updates, or deletes a resource record set with that name and
    /// type, and returns an <c>InvalidChangeBatch</c> error. To change a protected resource
    /// record set, first delete its protection by using <c>DeleteResourceRecordSetProtections</c>.
    /// 
    ///  
    /// <para>
    /// You can create a protection for a name and type that doesn't have a resource record
    /// set yet. In that case, Route 53 also rejects requests to create that resource record
    /// set.
    /// </para><para>
    /// You can't delete a hosted zone that has protections. To delete the hosted zone, first
    /// delete all of its protections by using <c>DeleteResourceRecordSetProtections</c>.
    /// </para><para>
    /// The request is atomic. Route 53 either creates all of the protections in the request
    /// or none of them. If one or more entries fail, the response is an error that lists
    /// the failing entries and the reason that each one failed. Route 53 checks for invalid
    /// entries before it checks for existing protections, so if any entry is invalid, the
    /// error lists only the invalid entries.
    /// </para><para>
    /// The error that Route 53 returns depends on the failures:
    /// </para><ul><li><para>
    /// If every entry already has a protection, Route 53 returns a <c>ProtectionAlreadyExists</c>
    /// error.
    /// </para></li><li><para>
    /// For any other combination of failures, Route 53 returns an <c>InvalidResourceRecordSetProtectionBatch</c>
    /// error.
    /// </para></li></ul><para>
    /// You can specify up to 100 protections in one request. The number of protections that
    /// you can have in a hosted zone is limited by a quota. If the request would exceed that
    /// quota, Route 53 returns a <c>LimitsExceeded</c> error.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53ResourceRecordSetProtection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateResourceRecordSetProtections API operation.", Operation = new[] {"CreateResourceRecordSetProtections"}, SelectReturnType = typeof(Amazon.Route53.Model.CreateResourceRecordSetProtectionsResponse))]
    [AWSCmdletOutput("None or Amazon.Route53.Model.CreateResourceRecordSetProtectionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Route53.Model.CreateResourceRecordSetProtectionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewR53ResourceRecordSetProtectionCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that contains the resource record sets that you want to
        /// protect.</para>
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
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Protection
        /// <summary>
        /// <para>
        /// <para>The protections to create. Each entry specifies a resource record set name and type,
        /// and an optional comment. The list must contain at least one entry and can contain
        /// up to 100 entries. Each name and type can appear only once in the list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Protections")]
        public Amazon.Route53.Model.ResourceRecordSetProtectionConfig[] Protection { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.CreateResourceRecordSetProtectionsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostedZoneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53ResourceRecordSetProtection (CreateResourceRecordSetProtections)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.CreateResourceRecordSetProtectionsResponse, NewR53ResourceRecordSetProtectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Protection != null)
            {
                context.Protection = new List<Amazon.Route53.Model.ResourceRecordSetProtectionConfig>(this.Protection);
            }
            #if MODULAR
            if (this.Protection == null && ParameterWasBound(nameof(this.Protection)))
            {
                WriteWarning("You are passing $null as a value for parameter Protection which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.CreateResourceRecordSetProtectionsRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.Protection != null)
            {
                request.Protections = cmdletContext.Protection;
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
        
        private Amazon.Route53.Model.CreateResourceRecordSetProtectionsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateResourceRecordSetProtectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateResourceRecordSetProtections");
            try
            {
                return client.CreateResourceRecordSetProtectionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public List<Amazon.Route53.Model.ResourceRecordSetProtectionConfig> Protection { get; set; }
            public System.Func<Amazon.Route53.Model.CreateResourceRecordSetProtectionsResponse, NewR53ResourceRecordSetProtectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
