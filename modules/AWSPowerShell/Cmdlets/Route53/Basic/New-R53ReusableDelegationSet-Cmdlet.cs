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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates a delegation set (a group of four name servers) that can be reused by multiple
    /// hosted zones that were created by the same Amazon Web Services account. 
    /// 
    ///  
    /// <para>
    /// You can also create a reusable delegation set that uses the four name servers that
    /// are associated with an existing hosted zone. Specify the hosted zone ID in the <code>CreateReusableDelegationSet</code>
    /// request.
    /// </para><note><para>
    /// You can't associate a reusable delegation set with a private hosted zone.
    /// </para></note><para>
    /// For information about using a reusable delegation set to configure white label name
    /// servers, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/white-label-name-servers.html">Configuring
    /// White Label Name Servers</a>.
    /// </para><para>
    /// The process for migrating existing hosted zones to use a reusable delegation set is
    /// comparable to the process for configuring white label name servers. You need to perform
    /// the following steps:
    /// </para><ol><li><para>
    /// Create a reusable delegation set.
    /// </para></li><li><para>
    /// Recreate hosted zones, and reduce the TTL to 60 seconds or less.
    /// </para></li><li><para>
    /// Recreate resource record sets in the new hosted zones.
    /// </para></li><li><para>
    /// Change the registrar's name servers to use the name servers for the new hosted zones.
    /// </para></li><li><para>
    /// Monitor traffic for the website or application.
    /// </para></li><li><para>
    /// Change TTLs back to their original values.
    /// </para></li></ol><para>
    /// If you want to migrate existing hosted zones to use a reusable delegation set, the
    /// existing hosted zones can't use any of the name servers that are assigned to the reusable
    /// delegation set. If one or more hosted zones do use one or more name servers that are
    /// assigned to the reusable delegation set, you can do one of the following:
    /// </para><ul><li><para>
    /// For small numbers of hosted zones—up to a few hundred—it's relatively easy to create
    /// reusable delegation sets until you get one that has four name servers that don't overlap
    /// with any of the name servers in your hosted zones.
    /// </para></li><li><para>
    /// For larger numbers of hosted zones, the easiest solution is to use more than one reusable
    /// delegation set.
    /// </para></li><li><para>
    /// For larger numbers of hosted zones, you can also migrate hosted zones that have overlapping
    /// name servers to hosted zones that don't have overlapping name servers, then migrate
    /// the hosted zones again to use the reusable delegation set.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "R53ReusableDelegationSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateReusableDelegationSetResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateReusableDelegationSet API operation.", Operation = new[] {"CreateReusableDelegationSet"}, SelectReturnType = typeof(Amazon.Route53.Model.CreateReusableDelegationSetResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateReusableDelegationSetResponse",
        "This cmdlet returns an Amazon.Route53.Model.CreateReusableDelegationSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53ReusableDelegationSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request, and that allows you to retry failed <code>CreateReusableDelegationSet</code>
        /// requests without the risk of executing the operation twice. You must use a unique
        /// <code>CallerReference</code> string every time you submit a <code>CreateReusableDelegationSet</code>
        /// request. <code>CallerReference</code> can be any unique string, for example a date/time
        /// stamp.</para>
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
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>If you want to mark the delegation set for an existing hosted zone as reusable, the
        /// ID for that hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Id")]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.CreateReusableDelegationSetResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.CreateReusableDelegationSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HostedZoneId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostedZoneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53ReusableDelegationSet (CreateReusableDelegationSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.CreateReusableDelegationSetResponse, NewR53ReusableDelegationSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HostedZoneId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CallerReference = this.CallerReference;
            #if MODULAR
            if (this.CallerReference == null && ParameterWasBound(nameof(this.CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostedZoneId = this.HostedZoneId;
            
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
            var request = new Amazon.Route53.Model.CreateReusableDelegationSetRequest();
            
            if (cmdletContext.CallerReference != null)
            {
                request.CallerReference = cmdletContext.CallerReference;
            }
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
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
        
        private Amazon.Route53.Model.CreateReusableDelegationSetResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateReusableDelegationSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateReusableDelegationSet");
            try
            {
                #if DESKTOP
                return client.CreateReusableDelegationSet(request);
                #elif CORECLR
                return client.CreateReusableDelegationSetAsync(request).GetAwaiter().GetResult();
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
            public System.String CallerReference { get; set; }
            public System.String HostedZoneId { get; set; }
            public System.Func<Amazon.Route53.Model.CreateReusableDelegationSetResponse, NewR53ReusableDelegationSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
